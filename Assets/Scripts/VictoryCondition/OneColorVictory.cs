using Scripts.Balls;
using Scripts.Enums;

namespace Scripts.VictoryCondition
{
    public class OneColorVictory : VictoryCondition
    {
        private BallColor _ballTypeBurst;

        public OneColorVictory(BallsController ballsController)
            : base(ballsController)
            => _ballTypeBurst = BallColor.None;

        protected override void OnDestroyedBall(Ball ball)
        {
            if (_ballTypeBurst == BallColor.None)
                _ballTypeBurst = ball.BallColor;

            if (_ballTypeBurst != ball.BallColor)
                FinishedInvoke(false);

            if (BallsController.CountByColor(_ballTypeBurst) == 0)
                FinishedInvoke(true);
        }
    }
}