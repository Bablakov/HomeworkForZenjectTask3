using Scripts.Balls;
using Scripts.Configs;
using Scripts.Enums;
using System;
using UnityEngine;

namespace Scripts.Factory
{
    public class BallFactory
    {
        private BallConfiguration _ballConfiguration;

        public BallFactory(BallConfiguration ballConfiguration)
            => _ballConfiguration = ballConfiguration;

        public Ball Get(BallColor ballColor)
            => GameObject.Instantiate(GetBall(ballColor));

        private Ball GetBall(BallColor ballColor) 
        {
            if (_ballConfiguration.TryGetBallConfig(ballColor, out BallConfig ballConfig))
                return ballConfig.Ball;

            throw new ArgumentException(nameof(ballColor));
        }
    }
}