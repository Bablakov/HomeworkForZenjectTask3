using Scripts.Mediators;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private VictoryConditionSelectionPanel _victoryConditionSelectionPanel;

        public override void InstallBindings()
        {
            BindVictoryConditionSelectionPanel();
            BindVictoryConditionSelectionMediator();
        }

        private void BindVictoryConditionSelectionPanel() 
            => Container.BindInterfacesAndSelfTo<VictoryConditionSelectionPanel>().FromInstance(_victoryConditionSelectionPanel);

        private void BindVictoryConditionSelectionMediator() 
            => Container.BindInterfacesAndSelfTo<VictoryConditionSelectionMediator>().AsSingle();
    }
}