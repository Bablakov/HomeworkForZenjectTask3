using System;
using Zenject;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class VictoryConditionSelectionPanel : MonoBehaviour, IInitializable, IDisposable
    {
        public event Action AllColorVictorySelected;
        public event Action OneColorVictorySelected;

        [SerializeField] private Button _allColorVictorySelecteButton;
        [SerializeField] private Button _oneColorVictorySelecteButton;

        public void Initialize()
            => Subscribe();

        public void Dispose()
            => Unsubscribe();

        private void Subscribe()
        {
            _allColorVictorySelecteButton.onClick.AddListener(OnAllColorVictorySelected);
            _oneColorVictorySelecteButton.onClick.AddListener(OnOneColorVictorySelecte);
        }

        private void Unsubscribe()
        {
            _allColorVictorySelecteButton.onClick.RemoveListener(OnAllColorVictorySelected);
            _oneColorVictorySelecteButton.onClick.RemoveListener(OnOneColorVictorySelecte);
        }

        private void OnAllColorVictorySelected()
            => AllColorVictorySelected?.Invoke();

        private void OnOneColorVictorySelecte()
            => OneColorVictorySelected?.Invoke();
    }
}