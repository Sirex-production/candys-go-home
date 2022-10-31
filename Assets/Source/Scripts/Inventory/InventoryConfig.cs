using System;
using UnityEngine;

namespace Candy.Inventory
{
	[CreateAssetMenu(menuName= "Inventory/InventoryConfig")]
	public sealed class InventoryConfig : ScriptableObject
	{
		[SerializeField] [Range(0, 1f)] private float pauseBetweenMeleeSlashes = .3f;
		[SerializeField] [Range(0, 100f)] private float meleeDamage = .3f;
		[SerializeField] private WeaponData[] weaponData;

		public float PauseBetweenMeleeSlashes => pauseBetweenMeleeSlashes;
		public float MeleeDamage => meleeDamage;
		public int AmountOfWeapons => weaponData.Length;
		public WeaponData GetWeaponData(int weaponId) => weaponData[weaponId];
	}

	[Serializable]
	public struct WeaponData
	{
		public float pauseBetweenShots;
		public float recoilStrength;
	}
}