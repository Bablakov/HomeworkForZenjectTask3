using System;
using System.Collections.Generic;
using System.Linq;
using Scripts.Balls;
using Scripts.Interfaces;
using Scripts.Enums;

namespace Scripts.VictoryCondition
{
    public class OneColorVictory : IVictoryCondition
    {
        public event Action<bool> Finished;

        private List<Ball> _balls;
        private IBallBurster _ballBurster;
        private BallColor _ballTypeBurst = BallColor.None;
        private bool _isCompleted;

        public OneColorVictory(IEnumerable<Ball> balls, IBallBurster ballBurster)
        {
            _balls = new List<Ball>(balls);
            _ballBurster = ballBurster;
            _ballBurster.BurstedBall += OnBurstedBall;
        }

        private void OnBurstedBall(Ball ball)
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
                    Finished?.Invoke(false);
                }

                if (_balls.Contains(ball))
                {
                    _balls.Remove(ball);
                }

                if (_balls.Where(ball => ball.BallColor == _ballTypeBurst).Count() == 0)
                {
                    _isCompleted = true;
                    Finished?.Invoke(true);
                }
            }
        }
    }
}