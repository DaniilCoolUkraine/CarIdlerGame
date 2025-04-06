using SimpleGame.Managers;
using UnityEngine;
using Zenject;

namespace SimpleGame.Installers
{
    public class ScoreManagerInstaller : MonoInstaller
    {
        [SerializeField] private ScoreManager _instance;

        public override void InstallBindings()
        {
            Container.Bind<ScoreManager>().FromInstance(_instance).AsSingle();
        }
    }
}