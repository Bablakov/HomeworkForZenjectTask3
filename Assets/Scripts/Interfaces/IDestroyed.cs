using System;
using UnityEngine;

namespace Scripts.Interfaces
{
    public interface IDestroyed
    {
        public event Action Destroyed;

        public Transform Transform { get; }
    }
}