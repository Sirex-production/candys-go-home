using System;
using UnityEngine;
using Zenject;

namespace Candy.Projectile
{
	public sealed class ProjectileSubject : MonoBehaviour
	{
		[SerializeField] private int id;
		[SerializeField] private float damage;
		
		public event Action<Vector3, Vector3, bool> OnLaunch;
		public event Action OnInitialStateReset;
		public event Action OnWithSurfaceInteract;

		private IProjectileService _projectileService;

		public float Damage => damage;
		
		[Inject]
		private void Construct(IProjectileService projectileService)
		{
			_projectileService = projectileService;
		}

		public void Launch(Vector3 position, Vector3 direction, bool isReleasedByPlayer)
		{
			OnLaunch?.Invoke(position, direction, isReleasedByPlayer);
		}

		public void ResetToInitialState()
		{
			OnInitialStateReset?.Invoke();
		}

		public void ResetProjectileViaService()
		{
			_projectileService.ResetProjectile(id, this);
		}

		public void InteractWithSurface()
		{
			OnWithSurfaceInteract?.Invoke();
			ResetProjectileViaService();
		}
	}
}