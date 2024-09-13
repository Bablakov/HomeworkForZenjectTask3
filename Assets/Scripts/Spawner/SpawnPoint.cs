using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Spawner
{
    public class SpawnPoint : MonoBehaviour
    {
        private IDestroyed _destroying;

        public bool IsEmpty => _destroying == null;

        public void Set(IDestroyed destroying)
        {
            _destroying = destroying;
            SetPosition();
            Subscribe();
        }

        private void SetPosition()
        {
            _destroying.Transform.position = transform.position;
            _destroying.Transform.rotation = transform.rotation;
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