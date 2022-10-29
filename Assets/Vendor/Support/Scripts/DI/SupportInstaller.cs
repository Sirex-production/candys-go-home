using NaughtyAttributes;
using Support.Audio;
using Support.Input;
using Support.SLS;
using UnityEngine;
using Zenject;

namespace Support.DI
{
    public sealed class SupportInstaller : MonoInstaller
    {
        [Required, SerializeField] private SaveLoadService saveLoadService;
        [Required, SerializeField] private AudioService audioService;
        [Required, SerializeField] private LevelManagementService levelManagementService;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<PcInputService>()
                .FromNew()
                .AsSingle();
            
            Container.Bind<SaveLoadService>()
                .FromInstance(saveLoadService)
                .AsSingle()
                .NonLazy();
            
            Container.Bind<LevelManagementService>()
                .FromInstance(levelManagementService)
                .AsSingle()
                .NonLazy();

            Container.Bind<AudioService>()
                .FromInstance(audioService)
                .AsSingle()
                .NonLazy();
        }
    }
}