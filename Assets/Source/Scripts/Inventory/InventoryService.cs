﻿using System;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Assertions;

namespace Candy.Inventory
{
	public sealed class InventoryService : MonoBehaviour, IInventoryService
	{
		[BoxGroup("Configs")]
		[Required, SerializeField] private InventoryConfig inventoryConfig;

		private bool _hasWeapons = false;
		private bool[] _currentWeapons;
		private int[] _currentAmountOfAmmunition;

		public event Action<bool[]> OnWeaponsUpdated;
		public event Action<int[]> OnAmmunitionUpdated;

		public bool HasGuns => _hasWeapons;
		
		private void Awake()
		{
			_currentWeapons = new bool[inventoryConfig.AmountOfWeapons];
			_currentAmountOfAmmunition = new int[inventoryConfig.AmountOfWeapons];
		}

		private void Start()
		{
			AddAmmunition(0, 30);
			AddAmmunition(1, 100);
			AddAmmunition(1, 3);
			
			OnWeaponsUpdated?.Invoke(_currentWeapons);
		}

		public void PickUpWeapon(int weaponId)
		{
			_hasWeapons = true;
			_currentWeapons[weaponId] = true;
			OnWeaponsUpdated?.Invoke(_currentWeapons);
		}

		public void AddAmmunition(int weaponId, int amount)
		{
			amount = Mathf.Max(0, amount);
			
			_currentAmountOfAmmunition[weaponId] += amount;
			OnAmmunitionUpdated?.Invoke(_currentAmountOfAmmunition);
		}

		public void WasteAmmunition(int weaponId, int amount)
		{
			amount = Mathf.Max(0, amount);
			
			_currentAmountOfAmmunition[weaponId] -= amount;
			OnAmmunitionUpdated?.Invoke(_currentAmountOfAmmunition);
		}

		public int GetNextWeaponIndex(int currentWeaponIndex)
		{
			Assert.IsTrue(currentWeaponIndex > -1 && currentWeaponIndex < _currentWeapons.Length);
			
			for (int i = 0; i < _currentWeapons.Length; i++)
			{
				currentWeaponIndex++;
				if (currentWeaponIndex >= _currentWeapons.Length)
					currentWeaponIndex = 0;

				if (_currentWeapons[currentWeaponIndex])
					return currentWeaponIndex;
			}
			
			throw new ApplicationException();
		}

		public int GetPreviousWeaponIndex(int currentWeaponIndex)
		{
			Assert.IsTrue(currentWeaponIndex > -1 && currentWeaponIndex < _currentWeapons.Length);
			
			for (int i = 0; i < _currentWeapons.Length; i++)
			{
				currentWeaponIndex--;
				if (currentWeaponIndex < 0)
					currentWeaponIndex = _currentWeapons.Length - 1;

				if (_currentWeapons[currentWeaponIndex])
					return currentWeaponIndex;
			}

			throw new ApplicationException();
		}

		public int GetAmountOfAmmunition(int weaponId)
		{
			if (weaponId < 0)
				return -1;
			
			return _currentAmountOfAmmunition[weaponId];
		}
	}
}