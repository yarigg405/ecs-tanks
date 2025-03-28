using Assets.Code.Gameplay.Input.Service;
using Assets.Code.Networking;
using Fusion;
using System.Collections.Generic;


namespace Assets.Code.Gameplay.Input.Network
{
    internal sealed class NetworkInputService : INetworkTickable
    {
        private readonly NetworkRunner _networkRunner;

        private Dictionary<PlayerRef, PlayerNetworkInput> _inputsMap = new();

        public NetworkInputService(NetworkRunner networkRunner)
        {
            _networkRunner = networkRunner;
        }

        public PlayerNetworkInput GetInput(PlayerRef player)
        {
            if (_inputsMap.TryGetValue(player, out var input))
                return input;
            return new();
        }

        void INetworkTickable.NetworkTick()
        {
            foreach (var player in _networkRunner.ActivePlayers)
            {
                if (_networkRunner.TryGetInputForPlayer<PlayerNetworkInput>(player, out PlayerNetworkInput input))
                    _inputsMap[player] = input;
            }
        }
    }
}
