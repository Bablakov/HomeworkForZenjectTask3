using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonWithExternalAction : MonoBehaviour
{
    private Button _button;

    public void Initialize(params UnityAction[] actionExitPanel)
    {
        GetComponent();
        AddMethodInEventClick(actionExitPanel);
    }

    protected virtual void GetComponent()
    {
        _button = GetComponent<Button>();
    }

    protected void AddMethodInEventClick(UnityAction[] actions)
    {
        foreach (var action in actions )
            _button.onClick.AddListener(action);
    }
}