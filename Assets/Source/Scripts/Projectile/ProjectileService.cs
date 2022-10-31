using System.Collections.Generic;
using NaughtyAttributes;
using Support.Input;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Candy.Projectile
{
	public sealed class ProjectileService : MonoBehaviour, IProjectileService
	{
		[BoxGroup("Configs")]
		[Required, SerializeField] private ProjectilesConfig projectilesConfig;
		
		private DiContainer _diContainer;

		private List<IObjectPool<ProjectileSubject>> _projectilesPools;
		
		[Inject]
		private void Construct(DiContainer diContainer, PcInputService pcInputService)
		{
			_diContainer = diContainer;
			
			pcInputService.OnAttackInput += () => SpawnProjectile(0, Camera.main.transform.position, Camera.main.transform.forward, true);
		}

		private void Awake()
		{
			_projectilesPools = new List<IObjectPool<ProjectileSubject>>(projectilesConfig.AmountOfProjectileTypes);
			
			for (int i = 0; i < projectilesConfig.AmountOfProjectileTypes; i++)
			{
				int projectileIndex = i;
				var objectPool = new ObjectPool<ProjectileSubject>
				(
					() => OnProjectileCreate(projectileIndex),
					OnProjectileGet,
					OnProjectileRelease,
					OnProjectileDestroy
				);
				
				_projectilesPools.Add(objectPool);
			}
		}

		public void SpawnProjectile(int projectileId, Vector3 launchPosition, Vector3 flyDirection, bool isReleasedByPlayer)
		{
			var projectile = _projectilesPools[projectileId].Get();

			projectile.Launch(launchPosition, flyDirection, isReleasedByPlayer);
		}

		public void ResetProjectile(int projectileId, ProjectileSubject projectileSubject)
		{
			_projectilesPools[projectileId].Release(projectileSubject);
		}

		private ProjectileSubject OnProjectileCreate(int projectileId)
		{
			var projectilePrefab = projectilesConfig.GetProjectile(projectileId);
			var projectile = _diContainer.InstantiatePrefabForComponent<ProjectileSubject>(projectilePrefab);

			return projectile;
		}

		private void OnProjectileGet(ProjectileSubject projectileSubject)
		{
			projectileSubject.ResetToInitialState();
		}

		private void OnProjectileRelease(ProjectileSubject projectileSubject)
		{
			projectileSubject.ResetToInitialState();
		}
		
		private void OnProjectileDestroy(ProjectileSubject projectileSubject)
		{
			projectileSubject.ResetToInitialState();
		}
	}
}