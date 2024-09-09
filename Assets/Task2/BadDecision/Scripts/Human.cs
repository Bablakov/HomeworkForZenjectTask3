using JetBrains.Annotations;
using UnityEngine;

namespace Task2BadDecision
{
    public class Human : MonoBehaviour
    {
        [SerializeField] private Gun _gun;
        [SerializeField, Range(0, 100)] private int _countBullet;

        private void Awake()
        {
            Debug.Log("Смена оружия. Установлено оружие с бесконечным количеством патронов");
            _gun.SetGunShooting(new InfinityShooter(Spawn));
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Смена оружия. Установлено оружие с бесконечным количеством патронов");
                _gun.SetGunShooting(new InfinityShooter(Spawn));
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                Debug.Log("Смена оружия. Установлено обычное оружие");
                _gun.SetGunShooting(new StandartShooter(Spawn, _countBullet));
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Смена оружия. Установлено оружие с мультишотом");
                _gun.SetGunShooting(new MultiShooter(Spawn, _countBullet));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Выстрел");
                _gun.Shoot();
            }
        }

        private void Spawn (Object spawnObject, Vector3 position, Quaternion rotation)
        {
            Instantiate(spawnObject, position, rotation);
        }
    }
}