using Scripts.SceneLoaderImport.Loader;
using Scripts.VictoryCondition;
using System;
using UnityEngine;

namespace Scripts.SceneLoaderImport
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
            Debug.Log("CreateVictoryConditionSelectionMediator");
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