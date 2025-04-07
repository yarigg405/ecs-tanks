using Assets.Code.Common.Entity;
using Assets.Code.Common.Extensions;
using Assets.Code.Gameplay.StaticData;
using Assets.Code.Infrastructure.Identifiers;
using System.Collections.Generic;
using UnityEngine;



namespace Assets.Code.Gameplay.Features.Shooting.Factory
{
    internal sealed class BulletsFactory
    {
        private readonly IdentifierService _identifier;
        private readonly StaticDataContainer _staticData;

        public BulletsFactory(IdentifierService identifier, StaticDataContainer staticData)
        {
            _identifier = identifier;
            _staticData = staticData;
        }

        public GameEntity CreateBullet(int level, Vector3 at)
        {
            var bulletLevel = _staticData.GetShootingLevel(level);
            var setup = bulletLevel.ProjectileSetup;

            return CreateEntity.Empty()
                .AddId(_identifier.Next())
                .With(x => x.isProjectile = true)
                .AddWorldPosition(at)
                .AddSpeed(setup.Speed)
                .AddRadius(setup.ContactRadius)
                .AddTargetsBuffer(new List<int>(4))
                .AddTargetLimit(setup.Pierce)
                .AddViewPrefab(bulletLevel.ViewPrefab)
                .With(x => x.isReadyToCollectTargets = true)
                .AddSelfDestructTimer(5f)
                ;
        }
    }
}
