using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Task4.Balls;
using Task4.Interfaces;

namespace Task4.VictoryDeterminant
{
    public class OneColorVictory : IVictoryDeterminant
    {
        private List<Ball> _balls;
        private IBallBurster _ballBurster;
        private Type _ballTypeBurst;
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
                if (_ballTypeBurst == null)
                {
                    _ballTypeBurst = ball.GetType();
                }
                else if (_ballTypeBurst != ball.GetType())
                {
                    _isCompleted = true;
                    LostGame?.Invoke();
                }

                if (_balls.Contains(ball))
                {
                    _balls.Remove(ball);
                }

                if (_balls.Where(ball => ball.GetType() == _ballTypeBurst).Count() == 0)
                {
                    _isCompleted = true;
                    WonGame?.Invoke();
                }
            }
        }

        public event Action WonGame;
        public event Action LostGame;
    }
}