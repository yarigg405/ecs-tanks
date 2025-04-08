using Assets.Code.Gameplay.Features.Shooting.Systems;
using Assets.Code.Gameplay.Features.TargetCollection.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Features.TargetCollection
{
    internal sealed class TargetCollectionFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CollectTargetIntervalSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CastForTargetsSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<FinalizeProcessedBullets>(Lifetime.Singleton).AsImplementedInterfaces();

            builder.Register<CleanupTargetBuffersSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
