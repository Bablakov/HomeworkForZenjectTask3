using Task4.Controllers;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    [SerializeField] private ButtonWithExternalAction _buttonStartAllBurst;
    [SerializeField] private ButtonWithExternalAction _buttonStartOneColor;

    public void Initialize(GameController gameController)
    {
        _buttonStartAllBurst.Initialize(StartGame, gameController.StartGameWithDestroyAllBall);
        _buttonStartOneColor.Initialize(StartGame, gameController.StartGameWithDestroyAllBallOneColor);
    }

    private void StartGame()
    {
        Disable();
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}