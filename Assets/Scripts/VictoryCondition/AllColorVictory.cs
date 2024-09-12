using Scripts.Balls;
using Scripts.Interfaces;

namespace Scripts.VictoryCondition
{
    public class AllColorVictory : VictoryCondition
    {
        public AllColorVictory(BallsController ballsController, IBallBurster ballBurster)
            : base(ballsController, ballBurster)
        { }

        protected override void OnBurstedBall(Ball ball)
        {
            if (BallsController.Contains(ball))
                BallsController.Remove(ball);

            if (BallsController.Count == 0)
                FinishedInvoke(true);
        }
    }
}