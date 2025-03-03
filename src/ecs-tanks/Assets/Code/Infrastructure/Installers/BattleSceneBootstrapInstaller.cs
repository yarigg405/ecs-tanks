using Assets.Code.Gameplay;
using Assets.Code.Gameplay.Features.Movement;
using Assets.Code.Gameplay.Features.Player;
using Assets.Code.Gameplay.Input;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class BattleSceneBootstrapInstaller : MonoInstaller
    {
        private IContainerBuilder _builder;

        public override void Install(IContainerBuilder builder)
        {
            _builder = builder;           
            BindFeatures();
        }

        private void BindFeatures()
        {
            new MovementFeatureInstaller().Install(_builder);
            new InputFeatureInstaller().Install(_builder);
            new PlayerFeatureInstaller().Install(_builder);

            _builder.Register<GameFeature>(Lifetime.Singleton).AsSelf();
        }
    }
}
