using Assets.Code.Common.Destruct;
using Assets.Code.Gameplay;
using Assets.Code.Gameplay.Common.Collisions;
using Assets.Code.Gameplay.Common.Time;
using Assets.Code.Gameplay.Features.Movement;
using Assets.Code.Gameplay.Features.Player;
using Assets.Code.Gameplay.Features.Player.Factory;
using Assets.Code.Gameplay.Input;
using Assets.Code.Gameplay.Input.Service;
using Assets.Code.Gameplay.Levels;
using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.Identifiers;
using Assets.Code.Infrastructure.Loading;
using Assets.Code.Infrastructure.States.GameStates;
using Assets.Code.Infrastructure.States.StateMachine;
using Assets.Code.Infrastructure.View;
using Assets.Code.Infrastructure.View.Factory;
using Code.Infrastructure;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        private IContainerBuilder _builder;

        public override void Install(IContainerBuilder builder)
        {
            _builder = builder;

            BindContexts();
            BindInfrastructureServices();
            BindCommonServices();
            BindFactories();
            BindStates();
            BindGameplayServices();
            BindFeatures();

            RegisterEntryPoint();
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
            _builder.Register<IdentifierService>(Lifetime.Singleton).AsSelf();
            _builder.Register<GameStateMachine>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<SceneLoader>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindCommonServices()
        {
            _builder.Register<UnityTimeService>(Lifetime.Singleton).AsImplementedInterfaces();
            _builder.Register<CollisionRegistry>(Lifetime.Singleton).AsImplementedInterfaces();
        }

        private void BindFactories()
        {
            _builder.Register<PlayerFactory>(Lifetime.Singleton).AsSelf();
            _builder.Register<EntityViewFactory>(Lifetime.Singleton).AsSelf();
        }

        private void BindStates()
        {
            _builder.Register<BootstrapState>(Lifetime.Transient).AsSelf();
            _builder.Register<LoadHomeScreenState>(Lifetime.Transient).AsSelf();
            _builder.Register<HomeScreenState>(Lifetime.Transient).AsSelf();

            _builder.Register<LoadBattleState>(Lifetime.Transient).AsSelf();
            _builder.Register<BattleEnterState>(Lifetime.Transient).AsSelf();
            _builder.Register<BattleLoopState>(Lifetime.Transient).AsSelf();
        }

        private void BindGameplayServices()
        {
            _builder.Register<LevelDataProvider>(Lifetime.Singleton).AsSelf();
        }

        private void BindFeatures()
        {
            new MovementFeatureInstaller().Install(_builder);
            new PlayerFeatureInstaller().Install(_builder);
            new BindViewFeatureInstaller().Install(_builder);
            new ProcessDestructFeatureInstaller().Install(_builder);

            _builder.Register<GameFeature>(Lifetime.Transient).AsSelf();
        }

        private void RegisterEntryPoint()
        {
            _builder.RegisterEntryPoint<GameEntryPoint>();
        }
    }
}
