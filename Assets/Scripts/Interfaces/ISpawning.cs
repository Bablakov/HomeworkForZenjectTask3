using UnityEngine;

namespace Scripts.Interfaces
{
    public interface ISpawning
    {
        public void SetPositionAndRotation(Vector3 position, Quaternion rotation);
    }
}