using NaughtyAttributes;
using Support.Extensions;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay
{
	public sealed class WeaponSwitcher : MonoBehaviour
	{
		[BoxGroup("References")]
		[SerializeField] private Transform meleeWeaponTransform;
		[BoxGroup("References")]
		[SerializeField] private Transform[] gunTransforms;
		[BoxGroup("References")]
		[Required, SerializeField] private Animator hudAnimator;
		[BoxGroup("Animation preferences")]
		[SerializeField] [Min(0)] private float delayBeforeSwitchingWeaponModels = .1f;
		
		private IGunplayService _gunplayService;
		private bool _isSwitchingWeapons = false;
		
		[Inject]
		private void Construct(IGunplayService gunplayService)
		{
			_gunplayService = gunplayService;
		}

		private void Awake()
		{
			_gunplayService.OnWeaponSwitched += OnWeaponSwitched;
			_gunplayService.OnMeleeWeaponSwitched += OnMeleeWeaponSwitched;
		}
		
		private void OnDestroy()
		{
			_gunplayService.OnWeaponSwitched -= OnWeaponSwitched;
		}

		private void OnWeaponSwitched(int currentWeaponIndex)
		{
			hudAnimator.ResetTrigger("WeaponSwitch");
			hudAnimator.SetTrigger("WeaponSwitch");
			_gunplayService.IsAbleToAttack = false;
			
			StopAllCoroutines();
			this.WaitAndDoCoroutine(delayBeforeSwitchingWeaponModels,
				() =>
				{
					meleeWeaponTransform.SetGameObjectInactive();
			
					for (int i = 0; i < gunTransforms.Length; i++)
						gunTransforms[i].gameObject.SetActive(currentWeaponIndex == i);
					
					_gunplayService.IsAbleToAttack = true;
				});
		}

		private void OnMeleeWeaponSwitched()
		{
			hudAnimator.ResetTrigger("WeaponSwitch");
			hudAnimator.SetTrigger("WeaponSwitch");
			_gunplayService.IsAbleToAttack = false;

			StopAllCoroutines();
			this.WaitAndDoCoroutine(delayBeforeSwitchingWeaponModels,
				() =>
				{
					foreach (var weaponTransform in gunTransforms)
						weaponTransform.SetGameObjectInactive();

					meleeWeaponTransform.SetGameObjectActive();
					
					_gunplayService.IsAbleToAttack = true;
				});
		}
	}
}