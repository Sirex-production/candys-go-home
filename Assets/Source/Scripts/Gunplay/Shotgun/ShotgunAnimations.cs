using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay.Shotgun
{
	public sealed class ShotgunAnimations : MonoBehaviour
	{
		[BoxGroup("References")]
		[SerializeField] private Animator shotgunAnimator;
		[BoxGroup("Properties")]
		[SerializeField] private int targetWeaponId;

		private IGunplayService _gunplayService;
		
		[Inject]
		private void Construct(IGunplayService gunplayService)
		{
			_gunplayService = gunplayService;
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
			if(targetWeaponId != weaponId)
				return;
			
			shotgunAnimator.ResetTrigger("Reload");
			shotgunAnimator.SetTrigger("Reload");
		}
	}
}