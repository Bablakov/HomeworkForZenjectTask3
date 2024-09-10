using System;
using System.Collections.Generic;
using Scripts.Balls;
using Scripts.Interfaces;

namespace Scripts.VictoryCondition
{
    public class AllBurstVictory : IVictoryCondition
    {
        public event Action<bool> Finished;

        private List<Ball> _balls;
        private IBallBurster _ballBurster;

        public AllBurstVictory(IEnumerable<Ball> balls, IBallBurster ballBurster)
        {
            _balls = new List<Ball>(balls);
            _ballBurster = ballBurster;
            _ballBurster.BurstedBall += OnBurstedBall;
        }

        private void OnBurstedBall(Ball ball)
        {
            if (_balls.Contains(ball))
                _balls.Remove(ball);

            if (_balls.Count == 0)
                Finished?.Invoke(true);
        }
    }
}