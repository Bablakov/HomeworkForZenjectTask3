using System;
using UnityEngine;

namespace Task2.Guns
{
    public class MultiGun : Gun
    {
        [SerializeField, Range(0, 100)] private int _countBullets;
        
        private Vector3 RangeBullet = new Vector3(0.05f, 0, 0);

        public override void Shoot()
        {
            if (_countBullets >= 3)
            {
                SpawnBullet();
                SpawnBullet(RangeBullet, Quaternion.identity);
                SpawnBullet(-RangeBullet, Quaternion.identity);
                _countBullets -= 3;
            }
            else if (_countBullets == 2)
            {
                SpawnBullet(-RangeBullet / 2, Quaternion.identity);
                SpawnBullet(RangeBullet / 2, Quaternion.identity);
                _countBullets -= 2;
            }
            else if (_countBullets == 1)
            {
                SpawnBullet();
                _countBullets--;
            }
            else
            {
                Debug.Log("Нет патронов");
            }
        }
    }
}