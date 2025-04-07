using Assets.Code.Gameplay.Features.LifetimeProcessing.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Features.LifetimeProcessing
{
    internal sealed class LifetimeFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<MarkDeadSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
