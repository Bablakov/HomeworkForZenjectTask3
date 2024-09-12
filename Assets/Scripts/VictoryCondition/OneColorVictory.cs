using Scripts.Balls;
using Scripts.Interfaces;
using Scripts.Enums;

namespace Scripts.VictoryCondition
{
    public class OneColorVictory : VictoryCondition
    {
        private BallColor _ballTypeBurst = BallColor.None;
        private bool _isCompleted;

        public OneColorVictory(BallsController ballsController, IBallBurster ballBurster)
            : base(ballsController, ballBurster)
        { }

        protected override void OnBurstedBall(Ball ball)
        {
            if (_isCompleted == false)
            {
                if (_ballTypeBurst == BallColor.None)
                {
                    _ballTypeBurst = ball.BallColor;
                }
                else if (_ballTypeBurst != ball.BallColor)
                {
                    _isCompleted = true;
                    FinishedInvoke(false);
                }

                if (BallsController.Contains(ball))
                {
                    BallsController.Remove(ball);
                }

                if (BallsController.CountByColor(_ballTypeBurst) == 0)
                {
                    _isCompleted = true;
                    FinishedInvoke(true);
                }
            }
        }
    }
}