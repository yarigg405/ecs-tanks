using Entitas;
using Fusion;


namespace Assets.Code.Common.Destruct.Systems
{
    internal sealed class CleanupGameDestructedViewsSystem : ICleanupSystem
    {
        private readonly IGroup<GameEntity> _entities;
        private readonly NetworkRunner _networkRunner;

        public CleanupGameDestructedViewsSystem(GameContext context, NetworkRunner networkRunner)
        {
            _entities = context.GetGroup(GameMatcher.AllOf(
                GameMatcher.Destructed,
                GameMatcher.View));
            _networkRunner = networkRunner;
        }

        void ICleanupSystem.Cleanup()
        {
            foreach (var entity in _entities)
            {
                entity.View.ReleaseEntity();
                _networkRunner.Despawn(entity.View);
            }
        }
    }
}
