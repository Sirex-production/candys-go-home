using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay.Rifle
{
	public sealed class RifleParticles : MonoBehaviour
	{
		[BoxGroup("References")] 
		[Required, SerializeField] private ParticleSystem shootParticle;
		[BoxGroup("Preferences")]
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
			
			shootParticle.Clear();
			shootParticle.Play();
		}
	}
}