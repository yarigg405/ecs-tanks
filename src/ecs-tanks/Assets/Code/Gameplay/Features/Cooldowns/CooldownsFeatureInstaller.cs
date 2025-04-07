using Assets.Code.Gameplay.Features.Cooldowns.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Features.Cooldowns
{
    internal sealed class CooldownsFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<CooldownSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
