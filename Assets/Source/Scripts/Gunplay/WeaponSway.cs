using NaughtyAttributes;
using Support.Input;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay
{
	public sealed class WeaponSway : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private Transform weaponOriginTransform;
		[BoxGroup("Sway properties")]
		[SerializeField] [Min(0)] private float initialRotationLerpingSpeed;
		[BoxGroup("Sway properties")]
		[SerializeField] [Min(0)] private float rotationForce;

		private PcInputService _pcInputService;

		private Quaternion _initialLocalRotation;
		
		[Inject]
		private void Construct(PcInputService pcInputService)
		{
			_pcInputService = pcInputService;
		}

		private void Awake()
		{
			_initialLocalRotation = weaponOriginTransform.localRotation;
			
			_pcInputService.OnDeltaRotationInput += OnDeltaRotationInput;
		}

		private void OnDestroy()
		{
			_pcInputService.OnDeltaRotationInput -= OnDeltaRotationInput;
		}

		private void OnDeltaRotationInput(Vector2 delta)
		{
			var rotationAngle = delta * (rotationForce * Time.deltaTime);
			var horizontalRotationOffset = Quaternion.AngleAxis(rotationAngle.y, Vector3.right);
			var verticalRotationOffset = Quaternion.AngleAxis(rotationAngle.x, Vector3.forward);
			var targetLocalRotation = weaponOriginTransform.localRotation * horizontalRotationOffset * verticalRotationOffset;

			weaponOriginTransform.localRotation = targetLocalRotation;
			weaponOriginTransform.localRotation = Quaternion.Lerp(weaponOriginTransform.localRotation, _initialLocalRotation, initialRotationLerpingSpeed * Time.deltaTime);
		}
	}
}