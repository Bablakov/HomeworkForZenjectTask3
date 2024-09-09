using UnityEngine;

namespace Task2.Guns
{
    public abstract class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private Transform _spawnPointBullet;

        public abstract void Shoot();

        protected Bullet SpawnBullet(Vector3 rangePosition, Quaternion rangeRotation)
        {
            var bullet = Instantiate(_bullet, rangePosition, rangeRotation);
            bullet.Launch();
            return bullet;
        }
    }
}