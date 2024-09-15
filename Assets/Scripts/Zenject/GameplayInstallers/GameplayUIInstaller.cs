using Scripts.Configs;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Scripts.Zenject.GameplayInstallers
{
    public class GameplayUIInstaller : MonoInstaller
    {
        [SerializeField] private UIConfig _uiConfig;
        [SerializeField] private Transform _transformParentUIPanels;

        public override void InstallBindings()
        {
            BindWinningPanel();
            BindDefeatPanel();
        }

        private void BindWinningPanel() 
            => Container.BindInterfacesAndSelfTo<WinningPanel>().FromComponentInNewPrefab(_uiConfig.WinningPanel)
            .UnderTransform(_transformParentUIPanels).AsSingle().NonLazy();

        private void BindDefeatPanel() 
            => Container.BindInterfacesAndSelfTo<DefeatPanel>().FromComponentInNewPrefab(_uiConfig.DefeatPanel)
            .UnderTransform(_transformParentUIPanels).AsSingle().NonLazy();
    }
}   