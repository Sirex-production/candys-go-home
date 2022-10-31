using System;
using System.Runtime.CompilerServices;
using Candy.Player;
using Cinemachine;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.CameraWork
{
	public sealed class CameraBobbing : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private PlayerMovement playerMovement;
		[BoxGroup("References")]
		[Required, SerializeField] private CinemachineVirtualCamera hudVCam;
		[BoxGroup("Bobbing properties")]
		[SerializeField] [Range(0, 1f)] private float bobbingStrength = 1f;
		[BoxGroup("Bobbing properties")]
		[SerializeField] [Range(0, 20f)] private float bobbingSpeed = 1f;
		[BoxGroup("Recoil properties")]
		[SerializeField] [Min(0)] private float recoilLerpSpeed = 10f;
		[BoxGroup("Recoil properties")]
		[SerializeField] [Min(0)] private float recoilStabilizationSpeed = 1f;

		private ICameraWorkService _cameraWorkService;
		
		private Transform _hudVCamTransform;
		private Vector3 _initialCameraLocalPos;
		private Vector3 _initialCameraLocalEulerAngles;
		private float _timeSpentTraveling = 0;
		private float _currentRecoilStrength = 0; 

		[Inject]
		private void Construct(ICameraWorkService cameraWorkService)
		{
			_cameraWorkService = cameraWorkService;
		}

		private void Awake()
		{
			_hudVCamTransform = hudVCam.transform;
			_initialCameraLocalPos = _hudVCamTransform.localPosition;
			_initialCameraLocalEulerAngles = _hudVCamTransform.localEulerAngles;

			_cameraWorkService.OnRecoilAdded += OnRecoilAdded;
		}

		private void OnDestroy()
		{
			_cameraWorkService.OnRecoilAdded -= OnRecoilAdded;
		}

		private void Update()
		{
			PerformBobbing();
			PerformRecoil();
		}

		private void OnRecoilAdded(float recoilStrength)
		{
			_currentRecoilStrength += recoilStrength;
		}

		private void OnLandEffectRequested()
		{
			
		}
		
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PerformBobbing()
		{
			if (playerMovement.CurrentOffset.sqrMagnitude < .001f || !playerMovement.IsGrounded)
			{
				_timeSpentTraveling = 0;
				_hudVCamTransform.localPosition = Vector3.Lerp(_hudVCamTransform.localPosition, _initialCameraLocalPos, 30f * Time.deltaTime);
				
				return;
			}

			var targetCameraLocalPos = _initialCameraLocalPos;
			targetCameraLocalPos += Vector3.up * (Mathf.Sin(_timeSpentTraveling * bobbingSpeed) * bobbingStrength);

			_hudVCamTransform.localPosition = targetCameraLocalPos;
			_timeSpentTraveling += Time.deltaTime;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void PerformRecoil()
		{
			var targetLocalEulerAngles = _initialCameraLocalEulerAngles;
			targetLocalEulerAngles.x -= _currentRecoilStrength;

			_hudVCamTransform.localEulerAngles = targetLocalEulerAngles;
			_currentRecoilStrength = Mathf.Lerp(_currentRecoilStrength, 0, recoilStabilizationSpeed * Time.deltaTime);
		}
	}
}