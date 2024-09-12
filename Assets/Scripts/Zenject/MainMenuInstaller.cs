using Scripts.SceneLoaderImport;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Zenject
{
    public class MainMenuInstaller : MonoInstaller
    {
        [SerializeField] private VictoryConditionSelectionPanel _victoryConditionSelectionPanel;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<VictoryConditionSelectionPanel>().FromInstance(_victoryConditionSelectionPanel);
            Container.BindInterfacesAndSelfTo<VictoryConditionSelectionMediator>().AsSingle();
        }
    }
}