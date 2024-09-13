using Scripts.Interfaces;

namespace Scripts.Spawner
{
    public class SpawnPointWithControllObject : SpawnPoint
    {
        private IDestroyed _destroying;

        public bool IsEmpty => _destroying == null;

        public void Set(IDestroyed destroying)
        {
            _destroying = destroying;
            Set((ISpawning)destroying);
            Subscribe();
        }

        private void Subscribe()
            => _destroying.Destroyed += OnDestroyed;

        private void Unsubscribe()
            => _destroying.Destroyed -= OnDestroyed;

        private void OnDestroyed()
        {
            Unsubscribe();
            _destroying = null;
        }
    }
}