using Assets.Code.Infrastructure.View;
using Entitas;


namespace Assets.Code.Common
{
    [Game] public class View : IComponent { public EntityBehaviour Value; }
    [Game] public class ViewPrefab : IComponent { public EntityBehaviour Value; }
    [Game] public class Destructed : IComponent { }
    [Game] public class SelfDestructTimer : IComponent { public float Value; }
}