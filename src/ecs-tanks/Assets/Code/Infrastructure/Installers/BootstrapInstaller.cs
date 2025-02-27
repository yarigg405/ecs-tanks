using Assets.Code.Gameplay;
using Assets.Code.Gameplay.Common.Time;
using Assets.Code.Gameplay.Features.Movement;
using Assets.Code.Gameplay.Features.Player;
using Assets.Code.Gameplay.Input;
using Assets.Code.Gameplay.Input.Service;
using Assets.Code.Infrastructure.DI;
using Code.Infrastructure;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        private IContainerBuilder _builder;

        public override void Install(IContainerBuilder builder)
        {
            _builder = builder;
            BindContexts();
            BindInfrastructureServices();
            BindCommonServices();
            BindFeatures();
        }

        private void BindContexts()
        {
            _builder.RegisterInstance(Contexts.sharedInstance).AsSelf();
            _builder.RegisterInstance(Contexts.sharedInstance.game).AsSelf();
            _builder.RegisterInstance(Contexts.sharedInstance.input).AsSelf();
            _builder.RegisterInstance(Contexts.sharedInstance.meta).AsSelf();
        }

        private void BindInfrastructureServices()
        {
            _builder.RegisterInstance(this).AsImplementedInterfaces();
        }

        private void BindCommonServices()
        {
            _builder.Register<StandaloneInputService>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<UnityTimeService>(Lifetime.Singleton).AsImplementedInterfaces();
        }




        private void BindFeatures()
        {
            new MovementFeatureInstaller().Install(_builder);
            new InputFeatureInstaller().Install(_builder);
            new PlayerFeatureInstaller().Install(_builder);

            _builder.Register<GameFeature>(Lifetime.Singleton).AsSelf();
        }





        void IInitializable.Initialize()
        {
            // Start game
        }
    }
}
