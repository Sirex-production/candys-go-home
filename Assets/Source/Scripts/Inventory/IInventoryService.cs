using System;

namespace Candy.Inventory
{
	public interface IInventoryService
	{
		public event Action<bool[]> OnWeaponsUpdated;
		public event Action<int[]> OnAmmunitionUpdated;

		public int GetNextWeaponIndex(int currentWeaponIndex);
		public int GetPreviousWeaponIndex(int currentWeaponIndex);
		public void PickUpWeapon(int weaponId);
		public void AddAmmunition(int weaponId, int amount);
		public void WasteAmmunition(int weaponId, int amount);
	}
}