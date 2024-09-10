using Scripts.Balls;
using Scripts.Configs;
using Scripts.Enums;
using UnityEngine;
using Zenject;

namespace Scripts.Factory
{
    public class BallFactory
    {
        private BallConfiguration _ballConfiguration;

        [Inject]
        private void Construct(BallConfiguration ballConfiguration)
            => _ballConfiguration = ballConfiguration;

        public Ball Get(BallColor ballColor)
        {
            /*switch(ballColor)
            {
                case BallColor.Red:
                    return GameObject.Instantiate(_ballConfiguration.TryGetBallConfig(ballColor))
            }*/
            return null;
        }

        private Ball GetBallColor(BallColor ballColor) 
        {
            return null;
        }
    }
}