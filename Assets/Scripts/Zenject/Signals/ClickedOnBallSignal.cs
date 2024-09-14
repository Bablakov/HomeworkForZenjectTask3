using Scripts.Balls;

namespace Assets.Scripts.Zenject.Signals
{
    public class ClickedOnBallSignal
    {
        public readonly Ball Ball;

        public ClickedOnBallSignal(Ball ball) 
            => Ball = ball;
    }
}