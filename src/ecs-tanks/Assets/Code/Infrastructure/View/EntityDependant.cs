using UnityEngine;


namespace Assets.Code.Infrastructure.View
{
    public abstract class EntityDependant : MonoBehaviour
    {
        [SerializeField] private EntityBehaviour _entityView;

        public GameEntity Entity => _entityView ? _entityView.Entity : null;

        private void Awake()
        {
            if (!_entityView)
                _entityView = GetComponent<EntityBehaviour>();
        }
    }
}
