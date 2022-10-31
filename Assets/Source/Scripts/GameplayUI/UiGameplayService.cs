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
		public event Action<int> OoWeaponSwitchUiUpdateRequested;
		public event Action<bool[]> OnInventoryUiWeaponsUpdateRequested;
		public event Action<float> OnHealthUiUpdateRequested;

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
			_gunplayService.OnWeaponSwitched += OnWeaponSwitched;
			_playerService.OnHealthUpdated += OnHealthUpdated;
		}

		private void OnDestroy()
		{
			_inventoryService.OnWeaponsUpdated -= OnWeaponsUpdated;
			_gunplayService.OnWeaponSwitched -= OnWeaponSwitched;
			_playerService.OnHealthUpdated -= OnHealthUpdated;
		}

		private void OnWeaponSwitched(int weaponIndex)
		{
			OoWeaponSwitchUiUpdateRequested?.Invoke(weaponIndex);
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