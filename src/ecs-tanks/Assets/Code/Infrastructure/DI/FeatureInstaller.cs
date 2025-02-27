using VContainer;
using VContainer.Unity;


namespace Assets.Code.Infrastructure.DI
{
    public abstract class FeatureInstaller: IInstaller
    {
        public abstract void Install(IContainerBuilder builder);
    }
}
