using Assets.Code.Gameplay.StaticData;
using Assets.Code.Infrastructure.DI;
using UnityEngine;
using VContainer;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class StaticDataInstaller : MonoInstaller
    {
        [SerializeField] private PrefabsContainer _prefabsContainer;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_prefabsContainer);
        }
    }
}
