using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Candy.LoadingUi
{
	public sealed class LoadingUiInstaller : MonoInstaller
	{
		[Required, SerializeField] private UiLoadingService uiLoadingService;
		
		public override void InstallBindings()
		{
			Container.Bind<IUiLoadingService>()
				.FromInstance(uiLoadingService)
				.AsSingle();
		}
	}
}