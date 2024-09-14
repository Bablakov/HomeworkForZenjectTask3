using Scripts.Controllers;
using Scripts.SceneLoaders;
using Scripts.UI;
using Scripts.Zenject.Signals;
using System;
using Zenject;

namespace Scripts.Mediators
{
    public class LevelMediator : IDisposable
    {
        private SceneLoadMediator _sceneLoadMediator;
        private WinningPanel _winningPanel;
        private DefeatPanel _defeatPanel;
        private SignalBus _signalBus;
        private Level _level;

        public LevelMediator(SceneLoadMediator sceneLoadMediator, WinningPanel winningPanel, DefeatPanel defeatPanel, Level level, SignalBus signalBus)
        {
            _sceneLoadMediator = sceneLoadMediator;
            _winningPanel = winningPanel;
            _defeatPanel = defeatPanel;
            _signalBus = signalBus;
            _level = level;
            Subscribe();
            DisablePanels();
        }

        public void Dispose()
            => Unsubscribe();

        private void Subscribe()
        {
            _level.DisplayedDefeatPanel += OnDisplayedDefeatPanel;
            _level.DisplayedWinningPanel += OnDisplayedWinningPanel;

            _winningPanel.ExitMainMenuClicked += OnExitMainMenuClicked;
            _winningPanel.RestarteClicked += OnRestarteClicked;

            _defeatPanel.RestarteClicked += OnRestarteClicked;
            _defeatPanel.ExitMainMenuClicked += OnExitMainMenuClicked;
        }

        private void Unsubscribe()
        {
            _level.DisplayedDefeatPanel -= OnDisplayedDefeatPanel;
            _level.DisplayedWinningPanel -= OnDisplayedWinningPanel;

            _winningPanel.ExitMainMenuClicked -= OnExitMainMenuClicked;
            _winningPanel.RestarteClicked -= OnRestarteClicked;

            _defeatPanel.RestarteClicked -= OnRestarteClicked;
            _defeatPanel.ExitMainMenuClicked -= OnExitMainMenuClicked;
        }

        private void OnDisplayedDefeatPanel()
        {
            _signalBus.Fire<FinishedGameSignal>();
            _defeatPanel.Enable();
        }

        private void OnDisplayedWinningPanel()
        {
            _signalBus?.Fire<FinishedGameSignal>();
            _winningPanel.Enable();
        }

        private void OnRestarteClicked()
        {
            DisablePanels();
            _signalBus.Fire<RestartedGameSignal>();
        }

        private void OnExitMainMenuClicked()
        {
            DisablePanels();
            _sceneLoadMediator.GoToMainMenu();
        }

        private void DisablePanels()
        {
            _defeatPanel.Disable();
            _winningPanel.Disable();
        }
    }
}