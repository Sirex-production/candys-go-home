using UnityEngine;

namespace Candy.Inventory
{
	[CreateAssetMenu(menuName= "Inventory/InventoryConfig")]
	public sealed class InventoryConfig : ScriptableObject
	{
		[SerializeField] [Min(0f)] private int amountOfWeapons;

		public int AmountOfWeapons => amountOfWeapons;
	}
}