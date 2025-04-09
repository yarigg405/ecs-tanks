using Assets.Code.Gameplay.Features.DamageApplication.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Features.DamageApplication
{
    internal class DamageApplicationFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ApplyDamageOnTargetsSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<HeathbarUpdateSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
