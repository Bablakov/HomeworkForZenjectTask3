using UnityEngine;
using Task2.Guns;

namespace Task2.Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private InifinityGun _infinityGun;
        [SerializeField] private StandartGun _standartGun;
        [SerializeField] private MultiGun _multiGun;
        
        private Gun _gun;

        private void Awake()
        {
            SetNewGun("Установлено оружие с бесконечным количеством патронов", _infinityGun);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
                SetNewGun("Смена оружия. Установлено оружие с бесконечным количеством патронов", _infinityGun);

            if (Input.GetKeyDown(KeyCode.W))
                SetNewGun("Смена оружия. Установлено обычное оружие", _standartGun);

            if (Input.GetKeyDown(KeyCode.E))
                SetNewGun("Смена оружия. Установлено оружие с мультишотом", _multiGun);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Выстрел");
                _gun.Shoot();
            }
        }

        private void SetNewGun(string text, Gun gun)
        {
            if (_gun != null)
                Destroy(_gun);

            Debug.Log(text);
            _gun = Instantiate(gun, transform);
        }
    }
}