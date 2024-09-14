using Scripts.Balls;
using Zenject;

namespace Scripts.VictoryCondition
{
    public class AllColorVictory : VictoryCondition
    {
        public AllColorVictory(BallsController ballsController)
            : base(ballsController)
        { }

        protected override void OnDestroyedBall(Ball ball)
        {
            if (BallsController.Count == 0)
                FinishedInvoke(true);
        }
    }
}