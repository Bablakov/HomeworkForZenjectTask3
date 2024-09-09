using System;
using UnityEngine;

namespace Task2.Guns
{
    public class StandartGun : Gun
    {
        [SerializeField, Range(0, 100)] private int _countBullets;

        public override void Shoot()
        {
            if (_countBullets > 0)
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