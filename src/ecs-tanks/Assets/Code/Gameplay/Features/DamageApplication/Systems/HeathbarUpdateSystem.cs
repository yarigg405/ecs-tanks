using Entitas;


namespace Assets.Code.Gameplay.Features.DamageApplication.Systems
{
    internal sealed class HeathbarUpdateSystem : IExecuteSystem
    {
        private readonly IGroup<GameEntity> _entities;

        internal HeathbarUpdateSystem(GameContext game)
        {
            _entities = game.GetGroup(GameMatcher.AllOf(
                GameMatcher.Healthbar,
                GameMatcher.MaxHP,
                GameMatcher.CurrentHP
            ));
        }

        void IExecuteSystem.Execute()
        {
            foreach (var entity in _entities)
            {
                entity.Healthbar.UpdateValue(entity.CurrentHP, entity.MaxHP);
            }
        }
    }
}