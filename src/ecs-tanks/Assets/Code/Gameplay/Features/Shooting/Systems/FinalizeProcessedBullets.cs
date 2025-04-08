using Assets.Code.Gameplay.Features.TargetCollection;
using Entitas;


namespace Assets.Code.Gameplay.Features.Shooting.Systems
{
    internal sealed class FinalizeProcessedBullets : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _bullets;

        internal FinalizeProcessedBullets(GameContext game)
        {
            _bullets = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Projectile,
                GameMatcher.Processed
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _bullets)
            {
                entity.RemoveTargetCollectionComponents();
                entity.isDestructed = true;
            }
        }
    }
}