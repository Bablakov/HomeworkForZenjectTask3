using Scripts.Interfaces;
using System;

namespace Scripts.Controllers
{
    public class Level : IDisposable
    {
        public event Action DisplayedWinningPanel;
        public event Action DisplayedDefeatPanel;

        private IVictoryCondition _victoryDeterminant;

        public Level(IVictoryCondition victoryCondition)
        {
            _victoryDeterminant = victoryCondition;
            Subscribe();
        }

        public void Dispose()
            => Unsubscribe();

        private void Subscribe()
            => _victoryDeterminant.Finished += OnFinished;

        private void Unsubscribe()
            => _victoryDeterminant.Finished -= OnFinished;

        private void OnFinished(bool isWin)
        {
            if (isWin)
                DisplayedWinningPanel?.Invoke();

            else
                DisplayedDefeatPanel?.Invoke();
        }
    }
}