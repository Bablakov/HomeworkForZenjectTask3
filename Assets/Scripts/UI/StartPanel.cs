using Scripts.Controllers;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour, IInitializable
{
    public event Action StartAllBurstClicked;
    public event Action StartOneColorBurstClicked;

    [SerializeField] private Button _buttonStartAllBurst;
    [SerializeField] private Button _buttonStartOneColor;

    public void Initialize()
    {
        _buttonStartAllBurst.onClick.AddListener(OnStartedAllBurstClicked);
        _buttonStartOneColor.onClick.AddListener(OnStartedOneColorBurstClicked);
    }

    public void Enable()
        => gameObject.SetActive(true);

    public void Disable()
        => gameObject.SetActive(false);

    private void OnStartedAllBurstClicked()
        => StartAllBurstClicked?.Invoke();

    private void OnStartedOneColorBurstClicked()
        => StartOneColorBurstClicked?.Invoke();
}