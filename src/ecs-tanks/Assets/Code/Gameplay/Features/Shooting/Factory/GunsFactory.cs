using Assets.Code.Common.Extensions;
using Assets.Code.Gameplay.Features.Cooldowns;
using Assets.Code.Gameplay.StaticData;


namespace Assets.Code.Gameplay.Features.Shooting.Factory
{
    public sealed class GunsFactory
    {
        private readonly StaticDataContainer _staticData;

        public GunsFactory(StaticDataContainer staticData)
        {
            _staticData = staticData;
        }

        public GameEntity CreateGun(GameEntity rootEntity, int level)
        {
            var gunLevel = _staticData.GetShootingLevel(level);

            return
            rootEntity
                .AddCooldown(gunLevel.Cooldown)
                .With(x => x.isShooter = true)
                .PutOnCooldown()
                ;
        }
    }
}
