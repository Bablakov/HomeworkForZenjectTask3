using Scripts.Enums;
using Scripts.Interfaces;
using UnityEngine;

namespace Scripts.Balls
{
    public class Ball : MonoBehaviour
    {
        public BallColor BallColor { get; private set; }

        public void Initialize(BallColor ballColor)
            => BallColor = ballColor;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBallBurster ballBurster))
            {
                ballBurster.ReactBallBurster(this);
                Destroy(gameObject);
            }
        }
    }
}