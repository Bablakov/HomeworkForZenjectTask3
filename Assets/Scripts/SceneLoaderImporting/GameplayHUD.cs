using Scripts.SceneLoaderImport.Loader;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Scripts.SceneLoaderImport
{
    public class GameplayHUD : MonoBehaviour
    {
        [SerializeField] private Button _mainMenuButton;

        private SceneLoadMediator _sceneLoader;

        [Inject]
        private void Construct(SceneLoadMediator sceneLoader, LevelLoadingData levelLoadingData)
        {
            _sceneLoader = sceneLoader;
            Debug.Log(levelLoadingData.Level);
        }

        private void OnEnable()
            => _mainMenuButton.onClick.AddListener(OnMainMenuClick);

        private void OnDisable()
            => _mainMenuButton.onClick.RemoveListener(OnMainMenuClick);

        private void OnMainMenuClick()
        {
            _sceneLoader.GoToMainMenu();
        }
    }
}