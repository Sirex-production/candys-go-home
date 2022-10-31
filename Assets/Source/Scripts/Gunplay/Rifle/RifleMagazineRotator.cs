using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay.Rifle
{
	public sealed class RifleMagazineRotator : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private Transform magazineTransform;
		[BoxGroup("Animation properties")]
		[SerializeField] private int currentGunId = 0;
		[BoxGroup("Animation properties")]
		[SerializeField] private Vector3 rotationAxis;
		[BoxGroup("Animation properties")]
		[SerializeField] [Range(0, 30f)] private float rotationAngle;

		private float _targetLocalEulerAngles;
		private IGunplayService _gunplayService;
		
		[Inject]
		private void Construct(IGunplayService gunplayService)
		{
			_gunplayService = gunplayService;
		}

		private void Awake()
		{
			_gunplayService.OnAttackPerformed += OnAttackPerformed;
			rotationAxis = rotationAxis.normalized;
		}

		private void OnDestroy()
		{
			_gunplayService.OnAttackPerformed -= OnAttackPerformed;
		}
		
		private void OnAttackPerformed(int weaponId)
		{
			if(weaponId != currentGunId)
				return;

			_targetLocalEulerAngles += rotationAngle;
			magazineTransform.localEulerAngles = rotationAxis * _targetLocalEulerAngles;
		}
	}
}