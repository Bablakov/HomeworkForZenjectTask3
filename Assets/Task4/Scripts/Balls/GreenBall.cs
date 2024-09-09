using UnityEngine;

namespace Task4.Balls
{
    public class GreenBall : Ball
    {
        protected override void Burst()
        {
            Debug.Log("Взорвался зелённый шарик");
        }
    }
}