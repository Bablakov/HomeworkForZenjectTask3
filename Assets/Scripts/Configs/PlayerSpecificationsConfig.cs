using System;
using UnityEngine;

namespace Scripts.Configs
{
    [Serializable]
    public class PlayerSpecificationsConfig
    {
        [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    }
}