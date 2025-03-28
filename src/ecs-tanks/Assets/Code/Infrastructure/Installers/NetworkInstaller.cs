using Assets.Code.Gameplay.Input.Network;
using Assets.Code.Infrastructure.DI;
using Assets.Code.Networking;
using Fusion;
using UnityEngine;
using VContainer;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class NetworkInstaller : MonoInstaller
    {
        [SerializeField] private NetworkRunner _runner;
        [SerializeField] private NetworkSceneManagerDefault _sceneManager;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_runner).AsSelf();
            builder.RegisterInstance(_sceneManager).AsImplementedInterfaces();
            builder.Register<NetworkGate>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<NetworkPlayerSpawner>(Lifetime.Singleton).AsSelf();
            builder.Register<NetworkInputPoller>(Lifetime.Singleton).AsSelf();
            builder.Register<NetworkInputService>(Lifetime.Singleton).AsSelf().AsImplementedInterfaces();
        }
    }
}
