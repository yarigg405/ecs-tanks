using Fusion;
using System.Threading.Tasks;
using UnityEngine;
using VContainer;


namespace Assets.Code.Infrastructure.View.Factory
{
    public class EntityViewFactory
    {
        private readonly IObjectResolver _resolver;
        private readonly NetworkRunner _runner;

        public EntityViewFactory(IObjectResolver resolver, NetworkRunner runner)
        {
            _resolver = resolver;
            _runner = runner;
        }

        public async Task<EntityBehaviour> CreateViewForEntity(GameEntity gameEntity, PlayerRef playerRef)
        {
            var prefab = gameEntity.ViewPrefab;
            var spawnPos = gameEntity.WorldPosition;

            var view = await _runner.SpawnAsync(prefab, spawnPos, Quaternion.identity, playerRef) as EntityBehaviour;

            _resolver.Inject(view);
            view.SetEntity(gameEntity);
            return view;
        }
    }
}
