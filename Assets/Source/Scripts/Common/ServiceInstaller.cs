using Candy.Gunplay;
using Candy.Player;
using Support;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Candy.Common
{
	public sealed class ServiceInstaller : MonoInstaller
	{
		[SerializeField] private PlayerService playerService;
		[SerializeField] private ProjectileService projectileService;
		
		public override void InstallBindings()
		{
			BindService<PlayerService, NullPlayerService, IPlayerService>(playerService);
			BindService<ProjectileService, NullProjectileService, IProjectileService>(projectileService);
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