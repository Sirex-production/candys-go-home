using Support;
using UnityEngine.SceneManagement;
using Zenject;

namespace Candy.Common
{
	public sealed class ServiceInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			base.InstallBindings();
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