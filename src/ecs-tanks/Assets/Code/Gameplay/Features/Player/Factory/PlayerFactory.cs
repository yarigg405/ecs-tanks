using Assets.Code.Common.Entity;
using Assets.Code.Infrastructure.Identifiers;
using System.Numerics;


namespace Assets.Code.Gameplay.Features.Player.Factory
{
    public sealed class PlayerFactory
    {
        private readonly IdentifierService _identifier;

        public PlayerFactory(IdentifierService identifier)
        {
            _identifier = identifier;
        }

        public GameEntity CreatePlayer()
        {
            return CreateEntity.Empty()
                .AddId(_identifier.Next())

                ;
        }
    }
}
