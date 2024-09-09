using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Task2BadDecision
{
    public class StandartShooter : IGunShooter
    {
        private int _countBullets;
        private Action<Object, Vector3, Quaternion> _spawnBullets;

        public StandartShooter(Action<Object, Vector3, Quaternion> spawnBullets, int countBullets)
        {
            _spawnBullets = spawnBullets;
            _countBullets = countBullets;
        }

        public void Shoot(Transform spawnPointBullet, Bullet bullet)
        {
            if (_countBullets > 0)
            {
                _spawnBullets(bullet, spawnPointBullet.position, spawnPointBullet.rotation);
                _countBullets--;
            }
            else
            {
                Debug.Log("Нет патронов");
            }
        }
    }
}