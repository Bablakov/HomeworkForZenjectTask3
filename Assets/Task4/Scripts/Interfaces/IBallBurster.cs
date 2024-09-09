using System;
using Task4.Balls;

namespace Task4.Interfaces
{
    public interface IBallBurster
    {
        public event Action<Ball> BurstedBall;
        public void ReactBallBurster(Ball ball);
    }
}