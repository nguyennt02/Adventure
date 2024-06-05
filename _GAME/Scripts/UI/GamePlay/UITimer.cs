using System;
using TMPro;
using UnityEngine;

public class UITimer : NewMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerText;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    private void LoadText()
    {
        if (_timerText) return;
        LogWarning("LoadText");
        _timerText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _timerText.text = TimerSystem.instance.timerText;
    }
}
