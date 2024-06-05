using System;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseSlider : NewMonoBehaviour
{
    [SerializeField] protected Slider _slider;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadSlider();
    }

    protected virtual void LoadSlider()
    {
        if (_slider) return;
        LogWarning("LoadSlider");
        _slider = GetComponent<Slider>();
    }
    protected virtual void Start()
    {
        AddOnClickEvent();
        SetValueSlider();
    }

    protected abstract void SetValueSlider();

    protected virtual void AddOnClickEvent()
    {
        _slider.onValueChanged.AddListener(onValueChanged);
    }

    protected abstract void onValueChanged(float value);
}
