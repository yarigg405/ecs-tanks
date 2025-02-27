using Entitas;
using System.Collections.Generic;


namespace Assets.Code.Gameplay
{
    public sealed class GameFeature : Feature
    {
        public GameFeature(IEnumerable<ISystem> systems)
        {
            foreach (var sys in systems)
            {
                Add(sys);
            }
        }
    }
}
