using Scripts.Enums;
using Scripts.Interfaces;
using System;
using UnityEngine;

namespace Scripts.Balls
{
    public class Ball : MonoBehaviour, IDestroyed
    {
        public event Action Destroyed;

        [field: SerializeField] public BallColor BallColor { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBallBurster ballBurster))
            {
                ballBurster.ReactBallBurster(this);
                Destroyed?.Invoke();
                Destroy(gameObject);
            }
        }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }
    }
}