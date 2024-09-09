using UnityEngine;

namespace Task2BadDecision
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _spawnPointBullet;

        private IGunShooter _gunShooter;

        public void SetGunShooting(IGunShooter gunShooter)
        {
            _gunShooter = gunShooter;
        }

        public void Shoot()
        {
            _gunShooter.Shoot(_spawnPointBullet, _bullet);
        }
    }
}