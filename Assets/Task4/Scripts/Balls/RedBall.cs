using UnityEngine;

namespace Task4.Balls
{
    public class RedBall : Ball
    {
        protected override void Burst()
        {
            Debug.Log("Взорвался красный шарик");
        }
    }
}