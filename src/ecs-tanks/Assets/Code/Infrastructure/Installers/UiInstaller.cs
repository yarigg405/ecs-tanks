using Assets.Code.Infrastructure.DI;
using UnityEngine;
using VContainer;
using Yrr.UI;


namespace Assets.Code.Infrastructure.Installers
{
    public sealed class UiInstaller : MonoInstaller
    {
        [SerializeField] private UIManager _uiManager;

        public override void Install(IContainerBuilder builder)
        {
            builder.RegisterInstance(_uiManager);
        }
    }
}
