using Candy.Actors;
using Candy.Inventory;
using NaughtyAttributes;
using Support;
using Support.Extensions;
using UnityEngine;
using Zenject;

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

		private LevelManagementService _levelManagementService;
		
		private readonly Collider[] _meleeAttackOverlappedSphereBuffer = new Collider[16];

		[Inject]
		private void Construct(LevelManagementService levelManagementService)
		{
			_levelManagementService = levelManagementService;
		}

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

		public void PlayTextEntry0()
		{
			NarrativeTextPresenter.Instance.PlayerPhrase0();
		}
		
		public void PlayTextEntry1()
		{
			NarrativeTextPresenter.Instance.PlayerPhrase1();
		}
		
		public void PlayTextEntry2()
		{
			NarrativeTextPresenter.Instance.PlayerPhrase2();
		}
		
		public void PlayTextEntry3()
		{
			NarrativeTextPresenter.Instance.PlayerPhrase3();
		}

		public void LoadFirstLevel()
		{
			_levelManagementService.LoadLevel(2);
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