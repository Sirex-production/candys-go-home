using NaughtyAttributes;
using Support.Input;
using UnityEngine;
using Zenject;

namespace Candy.Gunplay
{
	public sealed class WeaponSway : MonoBehaviour
	{
		[BoxGroup("References")]
		[SerializeField] private Transform[] weaponOriginTransforms;
		[BoxGroup("Sway properties")]
		[SerializeField] [Min(0)] private float initialRotationLerpingSpeed;
		[BoxGroup("Sway properties")]
		[SerializeField] [Min(0)] private float rotationForce;

		private PcInputService _pcInputService;

		private Quaternion[] _initialLocalRotations;
		
		[Inject]
		private void Construct(PcInputService pcInputService)
		{
			_pcInputService = pcInputService;
		}

		private void Awake()
		{
			_initialLocalRotations = new Quaternion[weaponOriginTransforms.Length];
			
			for (int i = 0; i < weaponOriginTransforms.Length; i++)
				_initialLocalRotations[i] = weaponOriginTransforms[i].localRotation;

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
			var verticalRotationOffset = Quaternion.AngleAxis(rotationAngle.x, Vector3.up);

			for (int i = 0; i < weaponOriginTransforms.Length; i++)
			{
				var targetLocalRotation = weaponOriginTransforms[i].localRotation * horizontalRotationOffset * verticalRotationOffset;
				weaponOriginTransforms[i].localRotation = targetLocalRotation;
				weaponOriginTransforms[i].localRotation = Quaternion.Lerp(weaponOriginTransforms[i].localRotation, _initialLocalRotations[i], initialRotationLerpingSpeed * Time.deltaTime);
			}
		}
	}
}