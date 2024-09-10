using Scripts.Balls;
using Scripts.Enums;
using Scripts.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Scripts.Spawner
{
    public class BallSpawner
    {
        private BallFactory _ballFactory;
        private List<SpawnPoint> _spawnPoints;

        private BallSpawner(BallFactory ballFactory, IEnumerable<SpawnPoint> spawnPoints)
        {
            _ballFactory = ballFactory;
            _spawnPoints = new List<SpawnPoint>(spawnPoints);
        }

        private bool CanSpawn => _spawnPoints.Any(spawnPoint => spawnPoint.IsEmpty);

        public bool TrySpawn(out IEnumerable<Ball> balls)
        {
            if (CanSpawn) 
            {
                balls = SpawnBalls();
                return true;
            }

            balls = null;
            return false;
        }

        private IEnumerable<Ball> SpawnBalls()
        {
            List<Ball> balls = new List<Ball>();
            foreach (var spawnPoint in _spawnPoints)
                if (spawnPoint.IsEmpty)
                {
                    Ball ball = _ballFactory.Get(GetRandomBallColor());
                    spawnPoint.Set(ball);
                    balls.Add(ball);
                }

            return balls;
        }

        private BallColor GetRandomBallColor()
        {
            int numberEnemyType = Enum.GetValues(typeof(BallColor)).Length;
            int randomNumber = Random.Range(0, numberEnemyType);

            return (BallColor)randomNumber;
        }
    }
}