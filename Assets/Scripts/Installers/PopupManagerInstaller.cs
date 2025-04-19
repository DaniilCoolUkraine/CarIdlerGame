using SimpleGame.Ui.Popups;
using UnityEngine;
using Zenject;

namespace SimpleGame.Installers
{
    public class PopupManagerInstaller : MonoInstaller
    {
        [SerializeField] private PopupManager _popupManager;
        
        public override void InstallBindings()
        {
            Container.Bind<IPopupManager>().To<PopupManager>().FromInstance(_popupManager).AsSingle();
        }
    }
}