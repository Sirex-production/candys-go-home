using System;
using Candy.Gunplay;
using Candy.Inventory;
using Candy.Player;
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

		private IInventoryService _inventoryService;
		private IGunplayService _gunplayService;
		private IPlayerService _playerService;
		
		[Inject]
		private void Construct(IInventoryService inventoryService, IGunplayService gunplayService, IPlayerService playerService)
		{
			_inventoryService = inventoryService;
			_gunplayService = gunplayService;
			_playerService = playerService;
		}

		private void Awake()
		{
			_inventoryService.OnWeaponsUpdated += OnWeaponsUpdated;
			_inventoryService.OnAmmunitionUpdated += OnAmmunitionUpdated;
			_gunplayService.OnWeaponSwitched += OnWeaponSwitched;
			_gunplayService.OnAttackPerformed += OnAttackPerformed;
			_gunplayService.OnMeleeWeaponSwitched += OnMeleeWeaponSwitched;
			_playerService.OnHealthUpdated += OnHealthUpdated;
		}

		private void OnDestroy()
		{
			_inventoryService.OnWeaponsUpdated -= OnWeaponsUpdated;
			_inventoryService.OnAmmunitionUpdated -= OnAmmunitionUpdated;
			_gunplayService.OnWeaponSwitched -= OnWeaponSwitched;
			_gunplayService.OnAttackPerformed -= OnAttackPerformed;
			_gunplayService.OnMeleeWeaponSwitched -= OnMeleeWeaponSwitched;
			_playerService.OnHealthUpdated -= OnHealthUpdated;
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
	}
}