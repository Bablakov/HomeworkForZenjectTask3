using Scripts.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Balls
{
    public class BallsController
    {
        public event Action<Ball> BallDestroyed;

        private List<Ball> _balls;

        public BallsController(IEnumerable<Ball> balls)
        {
            _balls = new List<Ball>(balls);
            foreach(Ball ball in balls)
                Subscribe(ball);
        }

        public int Count => _balls.Count;

        public void Add(Ball ball)
        {
            _balls.Add(ball);
            Subscribe(ball);
        }

        public void Remove(Ball ball)
        {
            _balls.Remove(ball);
            Unsubscribe(ball);
        }

        public bool Contains(Ball ball)
            => _balls.Contains(ball);

        public int CountByColor(BallColor ballColor)
            => _balls.Where(ball => ball.BallColor == ballColor).Count();

        private void Subscribe(Ball ball)
            => ball.Destroyed += OnDestroyed;

        private void Unsubscribe(Ball ball)
            => ball.Destroyed -= OnDestroyed;

        private void OnDestroyed(Ball ball)
        {
            Remove(ball);
            BallDestroyed?.Invoke(ball);
        }
    }
}