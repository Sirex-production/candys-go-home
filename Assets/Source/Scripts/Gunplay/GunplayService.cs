using System;
using Candy.Inventory;
using NaughtyAttributes;
using Support.Input;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay
{
	public sealed class GunplayService : MonoBehaviour, IGunplayService
	{
		[BoxGroup("Configs")]
		[Required, SerializeField] private InventoryConfig inventoryConfig;
		
		private PcInputService _pcInputService;
		private IInventoryService _inventoryService;

		private bool _isAbleToAttack = true;
		private int _currentWeaponIndex = 0;
		private bool _isHoldingMelee = false;
		private float _secondsPassedFromLastAttack = 0f;

		public bool IsAbleToAttack
		{
			get => _isAbleToAttack;
			set => _isAbleToAttack = value;
		}
		private bool CanPerformMeleeAttack => _secondsPassedFromLastAttack > inventoryConfig.PauseBetweenMeleeSlashes && _isHoldingMelee;
		private bool CanPerformShotFromCurrentWeapon
		{
			get
			{
				bool hasEnoughAmmunition = _inventoryService.GetAmountOfAmmunition(_currentWeaponIndex) > 0;
				bool enoughTimeHasPassed = _secondsPassedFromLastAttack >
				                           inventoryConfig.GetWeaponData(_currentWeaponIndex).pauseBetweenShots;

				return hasEnoughAmmunition && enoughTimeHasPassed && !_isHoldingMelee;
			}
		}

		public event Action<int> OnWeaponSwitched;
		public event Action OnMeleeWeaponSwitched;
		public event Action<int> OnAttackPerformed;

		[Inject]
		public void Construct(PcInputService pcInputService, IInventoryService inventoryService)
		{
			_pcInputService = pcInputService;
			_inventoryService = inventoryService;
		}

		private void Awake()
		{
			_pcInputService.OnAttackInput += OnAttackInput;
			_pcInputService.OnWeaponSwitch += OnWeaponSwitch;
			_pcInputService.OnMeleeWeaponSwitch += OnMeleeWeaponSwitch;
		}

		private void Start()
		{
			OnMeleeWeaponSwitch();
		}

		private void Update()
		{
			_secondsPassedFromLastAttack += Time.deltaTime;
		}

		private void OnDestroy()
		{
			_pcInputService.OnWeaponSwitch -= OnWeaponSwitch;
			_pcInputService.OnMeleeWeaponSwitch -= OnMeleeWeaponSwitch;
		}

		private void OnAttackInput()
		{
			if(!_isAbleToAttack)
				return;
			
			if (CanPerformMeleeAttack)
			{
				_secondsPassedFromLastAttack = 0f;
				OnAttackPerformed?.Invoke(-1);
				return;
			}

			if (CanPerformShotFromCurrentWeapon)
			{
				_secondsPassedFromLastAttack = 0f;
				OnAttackPerformed?.Invoke(_currentWeaponIndex);
			}
		}

		private void OnWeaponSwitch(bool isNext)
		{
			if(!_inventoryService.HasGuns)
				return;
			
			_secondsPassedFromLastAttack = 100f;
			_isHoldingMelee = false;
			_currentWeaponIndex = isNext ?
				_inventoryService.GetNextWeaponIndex(_currentWeaponIndex) :
				_inventoryService.GetPreviousWeaponIndex(_currentWeaponIndex);
			
			OnWeaponSwitched?.Invoke(_currentWeaponIndex);
		}

		private void OnMeleeWeaponSwitch()
		{
			_secondsPassedFromLastAttack = 100f;
			_isHoldingMelee = true;
			OnMeleeWeaponSwitched?.Invoke();
		}
	}
}