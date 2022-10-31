using NaughtyAttributes;
using UnityEngine;

namespace Candy.Projectile
{
	[RequireComponent(typeof(Rigidbody))]
	public sealed class ProjectileInteraction : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private ProjectileSubject projectileSubject;

		private bool _isReleasedByPlayer;

		private void Awake()
		{
			projectileSubject.OnLaunch += OnLaunch;
			projectileSubject.OnInitialStateReset += OnInitialStateReset;
		}

		private void OnDestroy()
		{
			projectileSubject.OnLaunch -= OnLaunch;
			projectileSubject.OnInitialStateReset -= OnInitialStateReset;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.isTrigger && !other.CompareTag("Player") && !other.CompareTag("Enemy"))
			{
				projectileSubject.InteractWithSurface();
				
				return;
			}

			if (other.CompareTag("Player") && !_isReleasedByPlayer)
			{
				//TODO - Viktor: Apply player damage here
				projectileSubject.InteractWithSurface();
				return;
			}

			if (other.CompareTag("Enemy") &&!_isReleasedByPlayer)
			{
				//TODO - Viktor: Apply enemy damage here
				projectileSubject.InteractWithSurface();
			}
		}

		private void OnLaunch(Vector3 _, Vector3 __, bool isReleasedByPlayer)
		{
			_isReleasedByPlayer = isReleasedByPlayer;
		}

		private void OnInitialStateReset()
		{
			_isReleasedByPlayer = false;
		}
	}
}