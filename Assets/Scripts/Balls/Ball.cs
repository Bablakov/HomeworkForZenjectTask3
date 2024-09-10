using Scripts.Enums;
using Scripts.Interfaces;
using System;
using UnityEngine;

namespace Scripts.Balls
{
    public class Ball : MonoBehaviour, IDestroyed
    {
        public event Action Destroyed;

        public Transform Transform => transform;

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
    }
}