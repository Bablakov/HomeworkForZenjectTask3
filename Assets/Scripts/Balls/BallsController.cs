using Scripts.Enums;
using System.Collections.Generic;
using System.Linq;

namespace Scripts.Balls
{
    public class BallsController
    {
        private List<Ball> _balls;

        public BallsController(IEnumerable<Ball> balls)
            => _balls = new List<Ball>(balls);

        public int Count => _balls.Count;

        public void Add(Ball ball)
            => _balls.Add(ball);

        public void Remove(Ball ball)
            => _balls.Remove(ball);

        public bool Contains(Ball ball)
            => _balls.Contains(ball);

        public int CountByColor(BallColor ballColor)
            => _balls.Where(ball => ball.BallColor == ballColor).Count();
    }
}