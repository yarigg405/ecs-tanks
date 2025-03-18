using Assets.Code.Infrastructure.DI;
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
        }
    }
}
