using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.View.Factory
{
    public class EntityViewFactory
    {
        private readonly IObjectResolver _resolver;

        public EntityViewFactory(IObjectResolver resolver)
        {
            _resolver = resolver;
        }

        public EntityBehaviour CreateViewForEntity(GameEntity gameEntity)
        {
            var prefab = gameEntity.ViewPrefab;
            var spawnPos = gameEntity.WorldPosition;

            var view = _resolver.Instantiate(prefab, spawnPos, Quaternion.identity);
            view.SetEntity(gameEntity);
            return view;
        }
    }
}
