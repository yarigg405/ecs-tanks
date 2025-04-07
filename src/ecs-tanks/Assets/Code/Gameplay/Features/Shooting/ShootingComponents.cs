using Entitas;


namespace Assets.Code.Gameplay.Features.Shooting
{
    [Game] public class Shooter : IComponent { }
    [Game] public class ShotRequested : IComponent { }
    [Game] public class Projectile : IComponent { }
    [Game] public class TeamComponent : IComponent { public Team Value; }
    [Game] public class TargetLimit : IComponent { public int Value; }

}
