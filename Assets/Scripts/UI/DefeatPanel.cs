using System;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class DefeatPanel : MonoBehaviour
    {
        public event Action RestarteClicked;
        public event Action ExitMainMenuClicked;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitMainMenuButton;

        private void OnEnable()
            => Subscribe();

        private void OnDisable()
            => Unsubscribe();

        public void Enable()
            => gameObject.SetActive(true);

        public void Disable()
            => gameObject.SetActive(false);

        private void Subscribe()
        {
            _restartButton.onClick.AddListener(OnRestarteClicked);
            _exitMainMenuButton.onClick.AddListener(OnExitMainMenuClicked);
        }

        private void Unsubscribe()
        {
            _restartButton.onClick.RemoveListener(OnRestarteClicked);
            _exitMainMenuButton.onClick.RemoveListener(OnExitMainMenuClicked);
        }

        private void OnRestarteClicked()
            => RestarteClicked?.Invoke();

        private void OnExitMainMenuClicked()
            => ExitMainMenuClicked?.Invoke();
    }
}