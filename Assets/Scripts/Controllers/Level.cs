using Scripts.Interfaces;
using System;
using UnityEngine;

namespace Scripts.Controllers
{
    public class Level : IDisposable
    {
        public event Action DisplayedWinningPanel;
        public event Action DisplayedDefeatPanel;

        private IVictoryCondition _victoryCondition;

        public void SetVictoryCondition(IVictoryCondition victoryCondition)
        {
            if (_victoryCondition != null)
                Unsubscribe();

            _victoryCondition = victoryCondition;
            Subscribe();
        }

        public void Dispose()
            => Unsubscribe();

        private void Subscribe()
            => _victoryCondition.Finished += OnFinished;

        private void Unsubscribe()
            => _victoryCondition.Finished -= OnFinished;

        private void OnFinished(bool isWin)
        {
            Debug.Log("Finished");

            if (isWin)
                DisplayedWinningPanel?.Invoke();

            else
                DisplayedDefeatPanel?.Invoke();
        }
    }
}