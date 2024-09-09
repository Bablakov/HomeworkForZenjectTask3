using UnityEngine;

namespace Task2BadDecision
{
    public interface IGunShooter
    {
        void Shoot(Transform spawnPointBullet, Bullet bullet);
    }
}