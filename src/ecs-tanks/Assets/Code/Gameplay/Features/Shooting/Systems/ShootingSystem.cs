using Assets.Code.Common.Extensions;
using Assets.Code.Gameplay.Features.Cooldowns;
using Assets.Code.Gameplay.Features.Shooting.Factory;
using Assets.Code.Gameplay.StaticData;
using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Features.Shooting.Systems
{
    internal sealed class ShootingSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _shooters;
        private readonly StaticDataContainer _staticData;
        private readonly BulletsFactory _bulletsFactory;

        private List<GameEntity> _buffer = new(16);

        internal ShootingSystem(GameContext game, StaticDataContainer staticData, BulletsFactory bulletsFactory)
        {
            _staticData = staticData;
            _shooters = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Shooter,
                GameMatcher.CooldownUp,
                GameMatcher.Team,
                GameMatcher.ShotRequested
            ));
            _bulletsFactory = bulletsFactory;
        }

        void IExecuteSystem.Execute()
        {
            foreach (var shooter in _shooters.GetEntities(_buffer))
            {
                var shotPos = shooter.Transform.position;
                shotPos.y += 0.5f;
                shotPos.x += shooter.Direction.x * 1.5f;
                shotPos.z += shooter.Direction.y * 1.5f;

                var bullet = _bulletsFactory.CreateBullet(1, shotPos)
                    .With(x => x.isMoving = true)
                    .With(x => x.isMovementAvailable = true)
                    .AddTeam(shooter.Team)
                    .ReplaceDirection(shooter.Direction)
                    ;

                shooter.PutOnCooldown(_staticData.GetShootingLevel(1).Cooldown);
                shooter.isShotRequested = false;
            }
        }
    }
}