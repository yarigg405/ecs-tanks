using Assets.Code.Gameplay.Features.Shooting.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Features.Shooting
{
    internal sealed class ShootingFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ShootingSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
