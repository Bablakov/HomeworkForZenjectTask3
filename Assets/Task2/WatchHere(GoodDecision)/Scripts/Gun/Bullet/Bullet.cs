using UnityEngine;

namespace Task2.Guns
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _speed = 5f;
        [SerializeField, Range(0, 10)] private float _timeLife = 3f;

        private bool _isInit = false;

        public void Launch()
        {
            _isInit = true;
            Destroy(gameObject, _timeLife);
        }

        private void Update()
        {
            if (_isInit)
                transform.position += transform.forward * _speed * Time.deltaTime;
        }
    }
}