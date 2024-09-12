using Scripts.Players;
using UnityEngine;
using Zenject;

namespace Scripts.Factory
{
    public class PlayerFactory
    {
        private IInstantiator _instantiator;

        public PlayerFactory(IInstantiator instantiator) =>
            _instantiator = instantiator;

        public Player Create(Vector3 position, Quaternion rotation)
        {
            Player player = _instantiator.Instantiate<Player>();

            player.transform.position = position;
            player.transform.rotation = rotation;

            return player;
        }
    }
}
