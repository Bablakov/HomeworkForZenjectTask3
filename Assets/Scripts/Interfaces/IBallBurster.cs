using System;
using Scripts.Balls;

namespace Scripts.Interfaces
{
    public interface IBallBurster
    {
        public event Action<Ball> BurstedBall;
        public void ReactBallBurster(Ball ball);
    }
}