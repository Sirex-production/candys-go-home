using Candy.CameraWork;
using Candy.Gunplay;
using Candy.Inventory;
using Candy.Projectile;
using Candy.Spawner.Service;
using Support;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Candy.Common
{
	public sealed class ServiceInstaller : MonoInstaller
	{
		[SerializeField] private GunplayService gunplayService;
		[SerializeField] private ProjectileService projectileService;
		[SerializeField] private InventoryService inventoryService;
		[SerializeField] private CameraWorkService cameraWorkService;
		[SerializeField] private EnemySpawnerService enemySpawnerService;
		public override void InstallBindings()
		{
			BindService<GunplayService, NullGunplayService, IGunplayService>(gunplayService);
			BindService<ProjectileService, NullProjectileService, IProjectileService>(projectileService);
			BindService<InventoryService, NullInventoryService, IInventoryService>(inventoryService);
			BindService<CameraWorkService, NullCameraService, ICameraWorkService>(cameraWorkService);
			BindService<EnemySpawnerService, NullEnemySpawnerService, IEnemySpawnerService>(enemySpawnerService);
		}
		
		private void BindService<TRealImplementation, TNullImplementation, TServiceInterface>(TRealImplementation realImplementation) 
			where TNullImplementation : TServiceInterface, new()
			where TRealImplementation : TServiceInterface
		{
			TServiceInterface bindInstance = realImplementation;

			if (bindInstance == null)
			{
				bindInstance = new TNullImplementation();
				
				string sceneName = SceneManager.GetActiveScene().name;
				TemplateUtils.SafeLog($"{typeof(TServiceInterface)} is null in scene \"{sceneName}\". Binding {typeof(TNullImplementation)}...");
			}

			Container.Bind<TServiceInterface>()
				.FromInstance(bindInstance)
				.AsSingle();
		}
	}
}