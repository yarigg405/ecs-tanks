using Assets.Code.Gameplay.StaticData;
using Assets.Code.Infrastructure.Identifiers;



namespace Assets.Code.Gameplay.Features.Shooting.Factory
{
    internal sealed class BulletsFactory
    {
        private readonly IdentifierService _identifier;
        private readonly PrefabsContainer _prefabsContainer;

        public BulletsFactory(IdentifierService identifier, PrefabsContainer prefabsContainer)
        {
            _identifier = identifier;
            _prefabsContainer = prefabsContainer;
        }

       // public GameEntity CreateBullet
    }
}
