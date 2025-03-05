using Assets.Code.Infrastructure.View.Registrars;


namespace Assets.Code.Gameplay.Common.Registrars
{
    public sealed class TransformRegistrar : EntityComponentRegistrar
    {
        public override void RegisterComponents()
        {
            Entity.AddTransform(transform);
        }

        public override void UnRegisterComponents()
        {
            Entity.RemoveTransform();
        }
    }
}
