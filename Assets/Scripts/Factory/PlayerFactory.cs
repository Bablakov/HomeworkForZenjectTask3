using Scripts.Configs;
using Scripts.Players;
using Scripts.Spawner;
using Zenject;

namespace Scripts.Factory
{
    public class PlayerFactory
    {
        private IInstantiator _instantiator;
        private PlayerConfig _playerConfig;

        public PlayerFactory(IInstantiator instantiator, PlayerConfig playerConfig)
        {
            _instantiator = instantiator;
            _playerConfig = playerConfig;
        }

        public Player Create(SpawnPoint spawnPoint)  
        {
            Player player = _instantiator.InstantiatePrefab(_playerConfig.Player).GetComponent<Player>();

            spawnPoint.Set(player);
            player.Initialize();

            return player;
        }
    }
}
