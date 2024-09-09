using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Task2BadDecision
{
    public class InfinityShooter : IGunShooter
    {
        private Action<Object, Vector3, Quaternion> _spawnBullets;

        public InfinityShooter(Action<Object, Vector3, Quaternion> spawnBullets)
        {
            _spawnBullets = spawnBullets;
        }

        public void Shoot(Transform spawnPointBullet, Bullet bullet)
        {
            _spawnBullets(bullet, spawnPointBullet.position, spawnPointBullet.rotation);
        }
    }
}