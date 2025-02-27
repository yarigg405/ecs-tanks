using Assets.Code.Common.Entity;
using Entitas;


namespace Assets.Code.Gameplay.Input.Systems
{
    public sealed class InitializeInputSystem : IInitializeSystem
    {
        void IInitializeSystem.Initialize()
        {
            CreateEntity.Empty()
                .isInput = true;
        }
    }
}
