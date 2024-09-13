using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Spawner
{
    public class SpawnPoint : MonoBehaviour
    {
        public void Set(ISpawning spawning)
        {
            SetPosition(spawning);
        }

        protected void SetPosition(ISpawning spawning)
            => spawning.SetPositionAndRotation(transform.position, transform.rotation);
    }
}