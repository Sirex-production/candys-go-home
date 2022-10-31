using Candy.Actors;
using Candy.Inventory;
using NaughtyAttributes;
using UnityEngine;

namespace Candy.Common
{
	public sealed class AnimatorCallbacks : MonoBehaviour
	{
		[BoxGroup("Config")]
		[Required, SerializeField] private InventoryConfig inventoryConfig;
		[BoxGroup("References")]
		[Required, SerializeField] private Transform meleeAttackOrigin;
		[BoxGroup("Melee attack properties")]
		[SerializeField] [Min(0)] private float radius;

		private readonly Collider[] _meleeAttackOverlappedSphereBuffer = new Collider[16];
		
		public void DealMeleeDamage()
		{
			var targetAttackSphereCenter = meleeAttackOrigin.position + meleeAttackOrigin.forward * radius;
			int amountOfHitColliders = Physics.OverlapSphereNonAlloc(targetAttackSphereCenter, radius, _meleeAttackOverlappedSphereBuffer);
			
			if(amountOfHitColliders < 1)
				return;

			for (int i = 0; i < _meleeAttackOverlappedSphereBuffer.Length; i++)
			{
				var hitCollider = _meleeAttackOverlappedSphereBuffer[i];
				
				if(hitCollider == null)
					continue;

				if (hitCollider.CompareTag("Enemy"))
				{
					float meleeDamage = inventoryConfig.MeleeDamage;
					if (hitCollider.transform.root.TryGetComponent<ActorHealth>(out var health))
					{
						health.TakeDamage(meleeDamage);
					}
				}

				_meleeAttackOverlappedSphereBuffer[i] = null;
			}
		}

		private void OnDrawGizmos()
		{
			if(meleeAttackOrigin == null)
				return;

			var targetAttackSphereCenter = meleeAttackOrigin.position + meleeAttackOrigin.forward * radius;
			
			Gizmos.color = Color.red;
			Gizmos.DrawWireSphere(targetAttackSphereCenter, radius);
		}
	}
}