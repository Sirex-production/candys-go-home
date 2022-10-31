using System;
using Candy.Gunplay;
using Candy.Inventory;
using Candy.Player;
using Support.Input;
using UnityEngine;
using Zenject;

namespace Candy.GameplayUi
{
	public sealed class UiGameplayService : MonoBehaviour, IUiGameplayService
	{
		public event Action<int> OnWeaponSwitchUiUpdateRequested;
		public event Action<bool[]> OnInventoryUiWeaponsUpdateRequested;
		public event Action<float> OnHealthUiUpdateRequested;
		public event Action<int> OnCurrentAmountOfAmmoUiUpdateRequested;
		public event Action OnEscPopupActivenessChange;

		private PcInputService _pcInputService;
		private IInventoryService _inventoryService;
		private IGunplayService _gunplayService;
		private IPlayerService _playerService;
		
		[Inject]
		private void Construct(PcInputService pcInputService, IInventoryService inventoryService, IGunplayService gunplayService, IPlayerService playerService)
		{
			_pcInputService = pcInputService;
			_inventoryService = inventoryService;
			_gunplayService = gunplayService;
			_playerService = playerService;
		}

		private void Awake()
		{
			_pcInputService.OnEscapeInputReceived += OnEscapeInputReceived;
			_inventoryService.OnWeaponsUpdated += OnWeaponsUpdated;
			_inventoryService.OnAmmunitionUpdated += OnAmmunitionUpdated;
			_gunplayService.OnWeaponSwitched += OnWeaponSwitched;
			_gunplayService.OnAttackPerformed += OnAttackPerformed;
			_gunplayService.OnMeleeWeaponSwitched += OnMeleeWeaponSwitched;
			_playerService.OnHealthUpdated += OnHealthUpdated;
		}

		private void OnDestroy()
		{
			_pcInputService.OnEscapeInputReceived -= OnEscapeInputReceived;
			_inventoryService.OnWeaponsUpdated -= OnWeaponsUpdated;
			_inventoryService.OnAmmunitionUpdated -= OnAmmunitionUpdated;
			_gunplayService.OnWeaponSwitched -= OnWeaponSwitched;
			_gunplayService.OnAttackPerformed -= OnAttackPerformed;
			_gunplayService.OnMeleeWeaponSwitched -= OnMeleeWeaponSwitched;
			_playerService.OnHealthUpdated -= OnHealthUpdated;
		}

		private void OnEscapeInputReceived()
		{
			ChangeEcsMenuActivity();
		}

		private void OnAmmunitionUpdated(int[] _)
		{
			OnAttackPerformed(_gunplayService.CurrentWeaponIndex);
		}

		private void OnMeleeWeaponSwitched()
		{
			OnWeaponSwitched(-1);
		}

		private void OnWeaponSwitched(int weaponIndex)
		{
			OnAttackPerformed(weaponIndex);
			OnWeaponSwitchUiUpdateRequested?.Invoke(weaponIndex);
		}

		private void OnAttackPerformed(int currentWeaponId)
		{
			int currentAmountOfAmmo = _inventoryService.GetAmountOfAmmunition(currentWeaponId);
			
			OnCurrentAmountOfAmmoUiUpdateRequested?.Invoke(currentAmountOfAmmo);
		}

		private void OnWeaponsUpdated(bool[] weapons)
		{
			OnInventoryUiWeaponsUpdateRequested?.Invoke(weapons);
		}

		private void OnHealthUpdated(float healthInPercentage)
		{
			OnHealthUiUpdateRequested?.Invoke(healthInPercentage);
		}
		
		public void ChangeEcsMenuActivity()
		{
			Cursor.visible = !Cursor.visible;
			Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
			
			OnEscPopupActivenessChange?.Invoke();
		}
	}
}