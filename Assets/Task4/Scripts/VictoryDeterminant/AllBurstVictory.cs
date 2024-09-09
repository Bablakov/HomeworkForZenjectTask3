using System;
using System.Collections.Generic;
using Task4.Balls;
using Task4.Interfaces;

namespace Task4.VictoryDeterminant
{
    public class AllBurstVictory : IVictoryDeterminant
    {
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
                WonGame?.Invoke();
        }

        public event Action WonGame;
        public event Action LostGame;
    }
}