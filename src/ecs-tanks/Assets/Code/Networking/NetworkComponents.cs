using Entitas;
using Fusion;


namespace Assets.Code.Networking
{
    [Game] public class PlayerRefComponent : IComponent { public PlayerRef Value; }
    [Game] public class LocalPlayer : IComponent { }
}
