using System;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public event Action StartAllBurstClicked;
    public event Action StartOneColorBurstClicked;

    [SerializeField] private Button _buttonStartAllBurst;
    [SerializeField] private Button _buttonStartOneColor;

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
        _buttonStartAllBurst.onClick.AddListener(OnStartedAllBurstClicked);
        _buttonStartOneColor.onClick.AddListener(OnStartedOneColorBurstClicked);
    }

    private void Unsubscribe()
    {
        _buttonStartAllBurst.onClick.RemoveListener(OnStartedAllBurstClicked);
        _buttonStartOneColor.onClick.RemoveListener(OnStartedOneColorBurstClicked);
    }

    private void OnStartedAllBurstClicked()
        => StartAllBurstClicked?.Invoke();

    private void OnStartedOneColorBurstClicked()
        => StartOneColorBurstClicked?.Invoke();
}