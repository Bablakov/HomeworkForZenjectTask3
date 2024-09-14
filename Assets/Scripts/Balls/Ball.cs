using Scripts.Enums;
using Scripts.Interfaces;
using System;
using UnityEngine;

namespace Scripts.Balls
{
    public class Ball : MonoBehaviour, IDestroyedBall, IClicked
    {
        public event Action<Ball> Destroyed;

        [field: SerializeField] public BallColor BallColor { get; private set; }

        public void SetPositionAndRotation(Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        public void ClickInteract()
        {
            Destroyed?.Invoke(this);
            Destroy(gameObject);
        }
    }
}