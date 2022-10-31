using System;

namespace Candy.Inventory
{
	public sealed class NullInventoryService : IInventoryService
	{
		public event Action<bool[]> OnWeaponsUpdated;
		public event Action<int[]> OnAmmunitionUpdated;

		public int GetNextWeaponIndex(int currentWeaponIndex)
		{
			return -1;
		}

		public int GetPreviousWeaponIndex(int currentWeaponIndex)
		{
			return -1;
		}

		public void PickUpWeapon(int weaponId)
		{
		}

		public void AddAmmunition(int weaponId, int amount)
		{
		}

		public void WasteAmmunition(int weaponId, int amount)
		{
		}
	}
}