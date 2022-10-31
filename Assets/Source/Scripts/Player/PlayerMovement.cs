using System.Runtime.CompilerServices;
using NaughtyAttributes;
using Support.Extensions;
using Support.Input;
using UnityEngine;
using Zenject;

namespace Candy.Player
{
	public sealed class PlayerMovement : MonoBehaviour
	{
		[BoxGroup("Configs")]
		[Required, SerializeField] private PlayerConfig playerConfig;
		
		[BoxGroup("References")]
		[Required, SerializeField] private CharacterController characterController;
		[BoxGroup("References")]
		[Required, SerializeField] private Transform hudTransform;

		[BoxGroup("Ground checking options")]
		[SerializeField] [Range(0f, 5f)] private float distanceToTheGround;
		[BoxGroup("Ground checking options")]
		[SerializeField] [Range(0f, 1f)] private float groundCheckingRadius;
		
		private PcInputService _pcInputService;
		private IPlayerService _playerService;

		private Transform _targetTransform;
		private float _jumpAcceleration;
		private float _currentRotationX;
		private float _currentMovementSpeed;
		private bool _isCustomJumpRequested;
		
		[SerializeField] [ReadOnly] private Vector3 _targetDirection;
		[SerializeField] [ReadOnly] private Vector3 _currentOffset;
		[SerializeField] [ReadOnly] private float _gravityForce;
		
		public bool IsGrounded
		{
			get
			{
				var ray = new Ray(_targetTransform.position, Vector3.down);
				int layerMask = ~LayerMask.GetMask("Ignore Raycast");
				
				return Physics.SphereCast
				(
					ray, groundCheckingRadius,
					distanceToTheGround, layerMask,
					QueryTriggerInteraction.Ignore
				);
			}
		}

		public Vector3 CurrentOffset => _currentOffset;
		
		[Inject]
		private void Construct(PcInputService pcInputService, IPlayerService playerService)
		{
			_pcInputService = pcInputService;
			_playerService = playerService;
		}

		private void Awake()
		{
			_currentMovementSpeed = playerConfig.MovementSpeed;
			_targetTransform = characterController.transform;

			_pcInputService.OnMoveInput += OnMoveInput;
			_pcInputService.OnJumpInput += OnJumpInput;
			_pcInputService.OnDeltaRotationInput += OnDeltaRotationInput;
			
			_playerService.OnCustomJumpRequested += OnCustomJumpRequested;
			_playerService.OnSpeedChangeRequested += OnSpeedChangeRequested;
		}

		private void OnDestroy()
		{
			_pcInputService.OnMoveInput -= OnMoveInput;
			_pcInputService.OnJumpInput -= OnJumpInput;
			_pcInputService.OnDeltaRotationInput -= OnDeltaRotationInput;
			
			_playerService.OnCustomJumpRequested -= OnCustomJumpRequested;
			_playerService.OnSpeedChangeRequested -= OnSpeedChangeRequested;
		}

		private void OnMoveInput(Vector2 movementInput)
		{
			_targetDirection = Vector3.zero;
			
			if (movementInput.sqrMagnitude <= 0.001f)
				return;

			var cameraForward = characterController.transform.forward;
			cameraForward.y = 0;
			cameraForward = cameraForward.normalized;
			var cameraRight = characterController.transform.right;
			cameraRight.y = 0;
			cameraRight = cameraRight.normalized;

			_targetDirection = cameraForward * movementInput.y + cameraRight * movementInput.x;
			_targetDirection = Vector3.ClampMagnitude(_targetDirection, 1);
		}

		private void OnJumpInput()
		{
			if(!IsGrounded)
				return;

			_jumpAcceleration = playerConfig.JumpForce;
		}

		private void OnDeltaRotationInput(Vector2 delta)
		{
			if(delta.sqrMagnitude < .001f)
				return;
			
			var offset = delta * (playerConfig.RotationSpeed * Time.deltaTime);

			_currentRotationX -= offset.y;
			_currentRotationX = Mathf.Clamp(_currentRotationX, -90, 90);
			
			characterController.transform.Rotate(Vector3.up, offset.x);

			var targetLocalEulerAngles = hudTransform.localEulerAngles;
			targetLocalEulerAngles.x = _currentRotationX;
			
			hudTransform.localEulerAngles = targetLocalEulerAngles;
		}

		private void OnCustomJumpRequested(float jumpForce)
		{
			_isCustomJumpRequested = true;
			_gravityForce = jumpForce;

			this.DoAfterNextFrameCoroutine(() => _isCustomJumpRequested = false);
		}

		private void OnSpeedChangeRequested(float targetSpeed)
		{
			_currentMovementSpeed = targetSpeed;
		}

		private void Update()
		{
			ApplyMovement();
			ApplyGravity();

			Transit();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ApplyMovement()
		{
			var targetOffset = _targetDirection * _currentMovementSpeed;

			_currentOffset = Vector3.Lerp(_currentOffset, targetOffset, playerConfig.AccelerationSpeed * Time.deltaTime);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void ApplyGravity()
		{
			if (_jumpAcceleration > 0)
			{
				_gravityForce = _jumpAcceleration;
				_jumpAcceleration -= playerConfig.Mass * Time.deltaTime;
				
				return;
			}

			if (IsGrounded && !_isCustomJumpRequested)
			{
				_gravityForce = 0;
				
				return;
			}
			
			_gravityForce -= playerConfig.Mass * Time.deltaTime;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void Transit()
		{
			characterController.Move(_currentOffset * Time.deltaTime);
			characterController.Move(_gravityForce * Vector3.up * Time.deltaTime);
		}

		private void OnDrawGizmos()
		{
			if(characterController == null)
				return;
			
			var currentPosition = characterController.transform.position;
			var pointNearGround = currentPosition + Vector3.down * distanceToTheGround;
			
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(currentPosition, pointNearGround);
			Gizmos.DrawSphere(pointNearGround, groundCheckingRadius);
		}
	}
}