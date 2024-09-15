using Scripts.Configs;
using Scripts.Mediators;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private UIMainMenuConfig _uiMainMenuConfig;
        [SerializeField] private Transform _transformParentUIPanels;

        public override void InstallBindings()
        {
            BindVictoryConditionSelectionPanel();
            BindVictoryConditionSelectionMediator();
        }

        private void BindVictoryConditionSelectionPanel()
            => Container.BindInterfacesAndSelfTo<VictoryConditionSelectionPanel>().FromComponentInNewPrefab(_uiMainMenuConfig.VictoryConditionSelectionPanel)
            .UnderTransform(_transformParentUIPanels).AsSingle().NonLazy();

        private void BindVictoryConditionSelectionMediator() 
            => Container.BindInterfacesAndSelfTo<VictoryConditionSelectionMediator>().AsSingle();
    }
}