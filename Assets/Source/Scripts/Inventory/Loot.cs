using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Inventory
{
	[RequireComponent(typeof(Collider) ,typeof(Rigidbody))]
	public sealed class Loot : MonoBehaviour
	{
		[BoxGroup("Configs")]
		[Required, SerializeField] private InventoryConfig inventoryConfig;
		[BoxGroup("Loot preferences")]
		[SerializeField] [Min(0)] private int ammunitionId = 0;
		[BoxGroup("Loot preferences")]
		[SerializeField] [Min(0)] private int amount = 0;

		private IInventoryService _inventoryService;
		
		[Inject]
		private void Construct(IInventoryService inventoryService)
		{
			_inventoryService = inventoryService;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				_inventoryService.AddAmmunition(ammunitionId, amount);
				Destroy(gameObject);
			}
		}

		private void OnValidate()
		{
			if (inventoryConfig == null)
			{
				Debug.LogError($"{nameof(inventoryConfig)} is null in {typeof(Loot)}");
				return;
			}

			ammunitionId = Mathf.Clamp(ammunitionId, 0, inventoryConfig.AmountOfWeapons);
		}
	}
}