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
        private List<SpawnPointWithControllBall> _spawnPoints;
        private BallsController _ballController;

        private BallSpawner(BallFactory ballFactory, IEnumerable<SpawnPointWithControllBall> spawnPoints)
        {
            _ballFactory = ballFactory;
            _spawnPoints = new List<SpawnPointWithControllBall>(spawnPoints);
            _ballController = new BallsController(new List<Ball>());
        }

        private bool CanSpawn => _spawnPoints.Any(spawnPoint => spawnPoint.IsEmpty);

        public bool TrySpawn(out BallsController balls)
        {
            if (CanSpawn) 
            {
                balls = SpawnBalls();
                return true;
            }

            balls = null;
            return false;
        }

        private BallsController SpawnBalls()
        {
            foreach (var spawnPoint in _spawnPoints)
                if (spawnPoint.IsEmpty)
                {
                    Ball ball = _ballFactory.Create(GetRandomBallColor());
                    spawnPoint.Set(ball);
                    _ballController.Add(ball);
                }

            return _ballController;
        }

        private BallColor GetRandomBallColor()
        {
            int numberEnemyType = Enum.GetValues(typeof(BallColor)).Length;
            int randomNumber = Random.Range(1, numberEnemyType);

            return (BallColor)randomNumber;
        }
    }
}