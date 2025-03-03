using Assets.Code.Gameplay.Features.Movement.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Features.Movement
{
    public sealed class MovementFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<DirectionalDeltaMoveSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<TurnAlongDirectionSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
