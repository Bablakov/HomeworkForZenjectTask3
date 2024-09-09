using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Task2BadDecision
{
    public class MultiShooter : IGunShooter
    {
        private Vector3 RangeBullet = new Vector3(0.05f, 0, 0);

        private int _countBullets;
        private Action<Object, Vector3, Quaternion> _spawnBullets;

        public MultiShooter(Action<Object, Vector3, Quaternion> spawnBullets, int countBullets)
        {
            _spawnBullets = spawnBullets;
            _countBullets = countBullets;
        }

        public void Shoot(Transform spawnPointBullet, Bullet bullet)
        {
            if (_countBullets >= 3)
            {
                _spawnBullets(bullet, spawnPointBullet.position, spawnPointBullet.rotation);
                _spawnBullets(bullet, spawnPointBullet.position + RangeBullet, spawnPointBullet.rotation);
                _spawnBullets(bullet, spawnPointBullet.position - RangeBullet, spawnPointBullet.rotation);
                _countBullets -= 3;
            }
            else if (_countBullets == 2)
            {
                _spawnBullets(bullet, spawnPointBullet.position - RangeBullet / 2, spawnPointBullet.rotation);
                _spawnBullets(bullet, spawnPointBullet.position + RangeBullet / 2, spawnPointBullet.rotation);
                _countBullets -= 2;
            }
            else if (_countBullets == 1)
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