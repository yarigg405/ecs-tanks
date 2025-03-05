using Assets.Code.Infrastructure.View.Registrars;
using UnityEngine;


namespace Assets.Code.Gameplay.Common.Registrars
{
    public sealed class RigidbodyRegistrar : EntityComponentRegistrar
    {
        [SerializeField] private Rigidbody _rigidbody;

        public override void RegisterComponents()
        {
            Entity.AddRigidbody(_rigidbody);
        }

        public override void UnRegisterComponents()
        {
            Entity.RemoveRigidbody();
        }
    }
}
