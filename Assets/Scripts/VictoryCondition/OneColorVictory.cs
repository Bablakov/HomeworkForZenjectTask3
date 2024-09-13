using Scripts.Balls;
using Scripts.Interfaces;
using Scripts.Enums;

namespace Scripts.VictoryCondition
{
    public class OneColorVictory : VictoryCondition
    {
        private BallColor _ballTypeBurst;

        public OneColorVictory(BallsController ballsController, IBallBurster ballBurster)
            : base(ballsController, ballBurster)
            => _ballTypeBurst = BallColor.None;

        protected override void OnBurstedBall(Ball ball)
        {
            if (BallsController.Contains(ball) == false)
                return;

            if (_ballTypeBurst == BallColor.None)
                _ballTypeBurst = ball.BallColor;

            if (BallsController.Contains(ball))
                BallsController.Remove(ball);

            if (_ballTypeBurst != ball.BallColor)
                FinishedInvoke(false);

            if (BallsController.CountByColor(_ballTypeBurst) == 0)
                FinishedInvoke(true);
        }
    }
}