using Scripts.Balls;
using Scripts.Interfaces;
using System;

namespace Scripts.VictoryCondition
{
    public abstract class VictoryCondition : IVictoryCondition
    {
        public event Action<bool> Finished;

        protected BallsController BallsController;
        protected IBallBurster BallBurster;

        public VictoryCondition(BallsController ballsController, IBallBurster ballBurster)
        {
            BallsController = ballsController;
            BallBurster = ballBurster;
            BallBurster.BurstedBall += OnBurstedBall;
        }

        protected void FinishedInvoke(bool isFinished)
            => Finished?.Invoke(isFinished);

        protected abstract void OnBurstedBall(Ball ball);
    }
}
