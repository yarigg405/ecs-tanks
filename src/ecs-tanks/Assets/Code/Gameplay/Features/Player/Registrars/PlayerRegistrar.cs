using Assets.Code.Common.Entity;
using Assets.Code.Common.Extensions;
using UnityEngine;


namespace Assets.Code.Gameplay.Features.Player.Registrars
{
    public sealed class PlayerRegistrar : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;
        [SerializeField] private Rigidbody _rb;

        private GameEntity _entity;

        private void Awake()
        {
            _entity = CreateEntity
                .Empty()
                .AddTransform(transform)
                .AddDirection(Vector2.zero)
                .AddSpeed(_speed)
                .AddRigidbody(_rb)
                .With(x => x.isPlayer = true)
                ;
        }
    }
}
