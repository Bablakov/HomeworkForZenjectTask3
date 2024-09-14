using Scripts.Balls;
using Scripts.Interfaces;
using System;

namespace Scripts.VictoryCondition
{
    public abstract class VictoryCondition : IVictoryCondition, IDisposable
    {
        public event Action<bool> Finished;

        protected BallsController BallsController;

        public VictoryCondition(BallsController ballsController)
        {
            BallsController = ballsController;
            Subscribe();
        }

        public void Dispose() => Unsubscribe();

        protected void FinishedInvoke(bool isFinished)
            => Finished?.Invoke(isFinished);

        protected abstract void OnDestroyedBall(Ball ball);

        private void Subscribe() 
            => BallsController.BallDestroyed += OnDestroyedBall;

        private void Unsubscribe()
            => BallsController.BallDestroyed -= OnDestroyedBall;
    }
}