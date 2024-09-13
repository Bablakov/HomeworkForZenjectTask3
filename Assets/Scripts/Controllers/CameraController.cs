using Cinemachine;
using Scripts.Zenject.Signals;
using UnityEngine;
using Zenject;

namespace Scripts.Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        private SignalBus _signalBus;

        [Inject]
        private void Construct(SignalBus signalBus)
            => _signalBus = signalBus;

        private void OnEnable()
            => Subscribe();

        private void OnDisable()
            => Unsubscribe();

        private void Subscribe()
            => _signalBus.Subscribe<SpawnTargetCameraSignal>(SetTargetFollow);

        private void Unsubscribe()
            => _signalBus.Unsubscribe<SpawnTargetCameraSignal>(SetTargetFollow);

        private void SetTargetFollow(SpawnTargetCameraSignal signal)
            => _cinemachineVirtualCamera.Follow = signal.TransformTarget;
    }
}