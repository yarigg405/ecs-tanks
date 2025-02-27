using Assets.Code.Gameplay.Input.Systems;
using Assets.Code.Infrastructure.DI;
using VContainer;


namespace Assets.Code.Gameplay.Input
{
    public sealed class InputFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<InitializeInputSystem>(Lifetime.Singleton).AsImplementedInterfaces();
            builder.Register<EmitInputSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
