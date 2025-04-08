using Assets.Code.Gameplay.Features.DamageApplication.Systems;
using Assets.Code.Infrastructure.DI;
using System;
using VContainer;


namespace Assets.Code.Gameplay.Features.DamageApplication
{
    internal class DamageApplicationFeatureInstaller : FeatureInstaller
    {
        public override void Install(IContainerBuilder builder)
        {
            builder.Register<ApplyDamageOnTargetsSystem>(Lifetime.Singleton).AsImplementedInterfaces();
        }
    }
}
