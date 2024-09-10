using Scripts.Enums;
using System.Linq;
using UnityEngine;

namespace Scripts.Configs
{
    [CreateAssetMenu(fileName = "new BallConfiguration", menuName = "Configs/BallConfiguration")]
    public class BallConfiguration : ScriptableObject
    {
        [field: SerializeField] private BallConfig[] _ballConfigs;

        public bool TryGetBallConfig(BallColor ballColor, out BallConfig ballConfig)
        {
            ballConfig = _ballConfigs
                .Where(ballConfig => ballConfig.BallColor == ballColor)
                .FirstOrDefault();

            return ballConfig != null;
        }

        private void OnValidate()
        {
            if (_ballConfigs.GroupBy(ballConfig => ballConfig.BallColor).Count() != _ballConfigs.Length)
                Debug.LogError("Ball color is not unique");
        }
    }
}