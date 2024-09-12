using Scripts.SceneLoaderImport.Loader;
using System;

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
        }

        public void Dispose() => Subscribe();

        private void Subscribe()
        {
            /*_victoryConditionSelectionPanel.AllColorVictorySelected += OnAllColorVictorySelected;
            _victoryConditionSelectionPanel.OneColorVictorySelected += OnOneColorVictorySelected;*/
        }

        private void Unsubscribe()
        {
            /*_victoryConditionSelectionPanel.AllColorVictorySelected -= OnAllColorVictorySelected;
            _victoryConditionSelectionPanel.OneColorVictorySelected -= OnOneColorVictorySelected;*/
        }

        private void OnOneColorVictorySelected() 
            => throw new System.NotImplementedException();
        private void OnAllColorVictorySelected() 
            => throw new System.NotImplementedException();
    }
}