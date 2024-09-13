using UnityEngine;

namespace Scripts.Zenject.Signals
{
    public class SpawnTargetCameraSignal
    {
        public readonly Transform TransformTarget;

        public SpawnTargetCameraSignal(Transform transformTarget)
            => TransformTarget = transformTarget;
    }
}