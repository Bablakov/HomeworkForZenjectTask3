using Task4.Interfaces;
using UnityEngine;

namespace Task4.Balls
{
    public abstract class Ball : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out IBallBurster ballBurster))
            {
                Burst();
                ballBurster.ReactBallBurster(this);
                Destroy(gameObject);
            }
        }

        protected abstract void Burst();
    }
}