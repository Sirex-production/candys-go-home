using System;
using Candy.Inventory;
using Support.Input;
using UnityEngine;
using Zenject;

namespace Candy.Player
{
	public sealed class GunplayService : MonoBehaviour, IGunplayService
	{
		private PcInputService _pcInputService;
		private IInventoryService _inventoryService;

		private int _currentWeaponIndex = 0;

		public event Action<int> OnWeaponSwitched;

		[Inject]
		public void Construct(PcInputService pcInputService, IInventoryService inventoryService)
		{
			_pcInputService = pcInputService;
			_inventoryService = inventoryService;
		}

		private void Awake()
		{
			_pcInputService.OnWeaponSwitch += OnWeaponSwitch;
		}

		private void OnDestroy()
		{
			_pcInputService.OnWeaponSwitch -= OnWeaponSwitch;
		}

		private void OnWeaponSwitch(bool isNext)
		{
			_currentWeaponIndex = isNext ?
				_inventoryService.GetNextWeaponIndex(_currentWeaponIndex) :
				_inventoryService.GetPreviousWeaponIndex(_currentWeaponIndex);
			
			OnWeaponSwitched?.Invoke(_currentWeaponIndex);
		}
	}
}