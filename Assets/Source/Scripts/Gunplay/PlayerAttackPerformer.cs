using Candy.CameraWork;
using Candy.Inventory;
using Candy.Projectile;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay
{
	public sealed class PlayerAttackPerformer : MonoBehaviour
	{
		[BoxGroup("Config")]
		[Required, SerializeField] private InventoryConfig inventoryConfig;
		[BoxGroup("References")]
		[Required, SerializeField] private Transform shootOriginTransform;
		[BoxGroup("References")]
		[Required, SerializeField] private Animator meleeWeaponAnimator;

		private IGunplayService _gunplayService;
		private IProjectileService _projectileService;
		private IInventoryService _inventoryService;
		private ICameraWorkService _cameraWorkService;
		
		[Inject]
		private void Construct(IGunplayService gunplayService, IProjectileService projectileService, IInventoryService inventoryService, ICameraWorkService cameraWorkService)
		{
			_gunplayService = gunplayService;
			_projectileService = projectileService;
			_inventoryService = inventoryService;
			_cameraWorkService = cameraWorkService;
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

			float recoilStrength = inventoryConfig.GetWeaponData(weaponId).recoilStrength;
			
			_projectileService.SpawnProjectile(weaponId, shootOriginTransform.position, shootOriginTransform.forward, true);
			_inventoryService.WasteAmmunition(weaponId, 1);
			_cameraWorkService.AddRecoil(recoilStrength);
		}
		
		private void PerformMeleeAttack()
		{
			meleeWeaponAnimator.ResetTrigger("Strike");
			meleeWeaponAnimator.SetTrigger("Strike");
		}
	}
}