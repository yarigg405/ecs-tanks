using Assets.Code.Infrastructure.DI;
using Assets.Code.Infrastructure.View.Systems;
using VContainer;


namespace Assets.Code.Infrastructure.View
{
    public sealed class BindViewFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<BindPlayerEntityViewFromPrefabSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<BindGameEntityViewFromPrefabSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
