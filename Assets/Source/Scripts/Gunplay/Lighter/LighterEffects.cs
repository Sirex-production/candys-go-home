using NaughtyAttributes;
using Support.Extensions;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay.Lighter
{
	public sealed class LighterEffects : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private Transform lighterButton;
		[BoxGroup("References")]
		[Required, SerializeField] private ParticleSystem flameParticleSystem;
		[BoxGroup("Preferences")]
		[SerializeField] private int targetWeaponId;
		[BoxGroup("Particle preferences")]
		[SerializeField] [Min(0)] private float delayToStopParticleAfterAttackFinished = .5f;
		[BoxGroup("Button preferences")]
		[SerializeField] [Min(0)] private Vector3 buttonPressLocalPosition;

		private IGunplayService _gunplayService;

		private Vector3 _initialButtonLocalPos;
		private float _secondsPassedFromLastShot = 0f;

		[Inject]
		private void Construct(IGunplayService gunplayService)
		{
			_gunplayService = gunplayService;
		}

		private void Awake()
		{
			_initialButtonLocalPos = lighterButton.localPosition;
			
			_gunplayService.OnAttackPerformed += OnAttackPerformed;
		}
		
		private void OnDestroy()
		{
			_gunplayService.OnAttackPerformed -= OnAttackPerformed;
		}

		private void Update()
		{
			if (_secondsPassedFromLastShot >= delayToStopParticleAfterAttackFinished)
			{
				lighterButton.localPosition = _initialButtonLocalPos;
				flameParticleSystem.Clear();
				return;
			}
			
			_secondsPassedFromLastShot += Time.deltaTime;
		}

		private void OnAttackPerformed(int weaponId)
		{
			if(targetWeaponId != weaponId)
				return;

			lighterButton.localPosition = buttonPressLocalPosition;
			
			_secondsPassedFromLastShot = 0f;
			flameParticleSystem.SetGameObjectActive();
			flameParticleSystem.Play();
		}
	}
}