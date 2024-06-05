using UnityEngine;
using UnityEngine.UI;

public abstract class BaseToggle : NewMonoBehaviour
{
    [SerializeField] protected Toggle _toggle;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadToggle();
    }

    protected virtual void LoadToggle()
    {
        if (_toggle) return;
        LogWarning("LoadToggle");
        _toggle = GetComponent<Toggle>();
    }

    protected virtual void Start()
    {
        AddOnClickEvent();
    }

    protected virtual void AddOnClickEvent()
    {
        _toggle.onValueChanged.AddListener(onValueChanged);
    }

    protected abstract void onValueChanged(bool isOn);
}
