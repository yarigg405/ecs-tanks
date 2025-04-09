using Assets.Code.Infrastructure.View.Registrars;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.LifetimeProcessing
{
    internal sealed class HealthbarRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Healthbar _healthbar;

        public override void RegisterComponents()
        {
            Entity.AddHealthbar(_healthbar);
        }

        public override void UnRegisterComponents()
        {
            Entity.RemoveHealthbar();
        }
    }
}
