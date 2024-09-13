using Scripts.Enums;
using Scripts.SceneLoaders;
using Scripts.UI;
using System;

namespace Scripts.Mediators
{
    public class VictoryConditionSelectionMediator : IDisposable
    {
        private VictoryConditionSelectionPanel _victoryConditionSelectionPanel;
        private SceneLoadMediator _sceneLoadMediator;

        public VictoryConditionSelectionMediator(VictoryConditionSelectionPanel victoryConditionSelectionPanel,
            SceneLoadMediator sceneLoadMediator)
        {
            _victoryConditionSelectionPanel = victoryConditionSelectionPanel;
            _sceneLoadMediator = sceneLoadMediator;
            Subscribe();
        }

        public void Dispose() => Unsubscribe();

        private void Subscribe()
        {
            _victoryConditionSelectionPanel.AllColorVictorySelected += OnAllColorVictorySelected;
            _victoryConditionSelectionPanel.OneColorVictorySelected += OnOneColorVictorySelected;
        }

        private void Unsubscribe()
        {
            _victoryConditionSelectionPanel.AllColorVictorySelected -= OnAllColorVictorySelected;
            _victoryConditionSelectionPanel.OneColorVictorySelected -= OnOneColorVictorySelected;
        }

        private void OnOneColorVictorySelected()
            => _sceneLoadMediator.GoToGameplayLevel(new LevelLoadingData(TypeCondition.OneColor));
        private void OnAllColorVictorySelected() 
            => _sceneLoadMediator.GoToGameplayLevel(new LevelLoadingData(TypeCondition.AllColor));
    }
}