using NaughtyAttributes;
using UnityEngine;

namespace Candy.Projectile
{
	public sealed class ProjectileShell : MonoBehaviour
	{
		[BoxGroup("References")]
		[Required, SerializeField] private ProjectileSubject projectileSubject;
		[BoxGroup("Shell properties")]
		[SerializeField] [Min(0)] private float growSpeed; 
		[BoxGroup("Shell properties")]
		[SerializeField] [Min(0)] private float lifeDuration;

		private Vector3 _initialLocalScale;
		private bool _isActive = false;
		private float _timeLeft = 0f;

		private void Awake()
		{
			_initialLocalScale = projectileSubject.transform.localScale;
			
			projectileSubject.OnLaunch += OnLaunch;
		}

		private void OnDestroy()
		{
			projectileSubject.OnLaunch -= OnLaunch;
		}

		private void Update()
		{
			if(!_isActive)
				return;

			if (_timeLeft < 0)
			{
				_isActive = false;
				
				projectileSubject.transform.localScale = _initialLocalScale; 
				projectileSubject.InteractWithSurface();
			}

			projectileSubject.transform.localScale += Vector3.one * (growSpeed * Time.deltaTime);
			_timeLeft -= Time.deltaTime;
		}

		private void OnLaunch(Vector3 _, Vector3 __, bool ___)
		{
			_isActive = true;
			_timeLeft = lifeDuration;
		}
	}
}