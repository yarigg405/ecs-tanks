using Fusion;
using System.Collections.Generic;
using VContainer;


namespace Assets.Code.Networking
{
    internal sealed class NetworkTickUpdater : SimulationBehaviour
    {
        private IEnumerable<INetworkTickable> _tickables;

        [Inject]
        private void Construct(IEnumerable<INetworkTickable> tickables)
        {
            _tickables = tickables;
        }

        public override void FixedUpdateNetwork()
        {
            foreach (var tickable in _tickables)
            {
                tickable.NetworkTick();
            }
        }
    }

    public interface INetworkTickable
    {
        void NetworkTick();
    }
}
