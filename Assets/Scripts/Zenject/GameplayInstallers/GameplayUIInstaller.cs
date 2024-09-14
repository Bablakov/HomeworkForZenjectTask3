using Scripts.Configs;
using UnityEngine;
using Zenject;

namespace Scripts.Zenject.GameplayInstallers
{
    public class GameplayUIInstaller : MonoInstaller
    {
        [SerializeField] private UIConfig _uiConfig;

        public override void InstallBindings()
        {
            /*Container.BindInterfacesAndSelfTo<WinningPanel>().FromInstance(_winningPanel);
            Container.BindInterfacesAndSelfTo<DefeatPanel>().FromInstance(_defeatPanel);*/
        }
    }
}