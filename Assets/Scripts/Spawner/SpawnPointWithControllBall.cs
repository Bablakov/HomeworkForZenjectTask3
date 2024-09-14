using Scripts.Balls;
using Scripts.Interfaces;

namespace Scripts.Spawner
{
    public class SpawnPointWithControllBall : SpawnPoint
    {
        private IDestroyedBall _destroying;

        public bool IsEmpty => _destroying == null;

        public void Set(IDestroyedBall destroying)
        {
            _destroying = destroying;
            Set((ISpawning)destroying);
            Subscribe();
        }

        private void Subscribe()
            => _destroying.Destroyed += OnDestroyed;

        private void Unsubscribe()
            => _destroying.Destroyed -= OnDestroyed;

        private void OnDestroyed(Ball ball)
        {
            Unsubscribe();
            _destroying = null;
        }
    }
}