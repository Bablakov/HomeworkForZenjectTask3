using UnityEngine;

namespace Task4.Balls
{
    public class WhiteBall : Ball
    {
        protected override void Burst()
        {
            Debug.Log("Взорвался белый шарик");
        }
    }
}