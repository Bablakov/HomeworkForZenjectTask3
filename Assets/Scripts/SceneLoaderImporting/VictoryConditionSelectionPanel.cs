using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.SceneLoaderImport
{
    public class VictoryConditionSelectionPanel : MonoBehaviour
    {
        public event Action AllColorVictorySelected;
        public event Action OneColorVictorySelected;

        [SerializeField] private Button _allColorVictorySelecteButton;
        [SerializeField] private Button _oneColorVictorySelecteButton;

        private void OnEnable() => Subscribe();

        private void OnDisable() => Unsubscribe();

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