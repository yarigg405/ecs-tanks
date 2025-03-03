using Assets.Code.Gameplay.Common.Time;
using Assets.Code.Gameplay.Input.Service;
using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.StateMachine;
using Code.Infrastructure;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class GameBootstrapInstaller : MonoInstaller, ICoroutineRunner, IInitializable
    {
        private IContainerBuilder _builder;

        public override void Install(IContainerBuilder builder)
        {
            _builder = builder;

            BindContexts();
            BindInfrastructureServices();
            BindCommonServices();
            BindStates();
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
            _builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindCommonServices()
        {
            _builder.Register<StandaloneInputService>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<UnityTimeService>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindStates()
        {

        }


        void IInitializable.Initialize()
        {
            // Start game
        }
    }
}
