using Assets.Code.Common.Destruct.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Common.Destruct
{
    internal sealed class ProcessDestructFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<SelfDestructTimerSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CleanupGameDestructedViewsSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<CleanupGameDestructedSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
