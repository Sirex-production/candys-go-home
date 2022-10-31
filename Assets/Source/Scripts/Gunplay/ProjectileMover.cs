using NaughtyAttributes;
using Support.Extensions;
using UnityEngine;

namespace Candy.Gunplay
{
	public sealed class ProjectileMover : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private ProjectileSubject projectileSubject;
		[BoxGroup("References")]
		[Required, SerializeField] private Rigidbody projectileRigidbody;
		[BoxGroup("Properties")]
		[SerializeField] [Min(0)] private float speed;

		private Transform _projectileTransform;
		private bool _isFlying = false;

		private void Awake()
		{
			_projectileTransform = projectileRigidbody.transform;

			projectileSubject.OnLaunch += OnLaunch;
			projectileSubject.OnInitialStateReset += OnInitialStateReset;
		}

		private void OnDestroy()
		{
			projectileSubject.OnLaunch -= OnLaunch;
			projectileSubject.OnInitialStateReset -= OnInitialStateReset;
		}
		
		private void FixedUpdate()
		{
			if(!_isFlying)
				return;
			
			_projectileTransform.position += _projectileTransform.forward * (speed * Time.fixedDeltaTime);
		}

		private void OnLaunch(Vector3 position, Vector3 direction, bool _)
		{
			this.SetGameObjectActive();
			
			_projectileTransform.position = position;
			_projectileTransform.rotation = Quaternion.LookRotation(direction);
			
			_isFlying = true;
		}

		private void OnInitialStateReset()
		{
			_isFlying = false;
			this.SetGameObjectInactive();
		}
	}
}