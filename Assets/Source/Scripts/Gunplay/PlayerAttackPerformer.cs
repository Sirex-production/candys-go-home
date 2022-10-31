using Candy.Projectile;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay
{
	public sealed class PlayerAttackPerformer : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private Transform shootOriginTransform;
		[BoxGroup("References")]
		[Required, SerializeField] private Animator meleeWeaponAnimator;
		[BoxGroup("References")]
		[Required, SerializeField] private Animation strikeAnimation;
		
		private IGunplayService _gunplayService;
		private IProjectileService _projectileService;
		
		[Inject]
		private void Construct(IGunplayService gunplayService, IProjectileService projectileService)
		{
			_gunplayService = gunplayService;
			_projectileService = projectileService;
		}

		private void Awake()
		{
			_gunplayService.OnAttackPerformed += OnAttackPerformed;
		}

		private void OnDestroy()
		{
			_gunplayService.OnAttackPerformed -= OnAttackPerformed;
		}

		private void OnAttackPerformed(int weaponId)
		{
			if (weaponId < 0)
			{
				PerformMeleeAttack();
				return;
			}

			_projectileService.SpawnProjectile(weaponId, shootOriginTransform.position, shootOriginTransform.forward, true);
		}
		
		private void PerformMeleeAttack()
		{
			meleeWeaponAnimator.ResetTrigger("Strike");
			meleeWeaponAnimator.SetTrigger("Strike");
		}
	}
}