using Assets.Code.Gameplay.Features.Player.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Features.Player
{
    public sealed class PlayerFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<SetPlayerDirectionByInputSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
