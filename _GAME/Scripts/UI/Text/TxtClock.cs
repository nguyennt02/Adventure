using System;
using TMPro;
using UnityEngine;

public class TxtClock : NewMonoBehaviour
{
    [SerializeField] TextMeshProUGUI _timerText;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTextClock();
    }

    private void LoadTextClock()
    {
        if(_timerText != null ) return;
        LogWarning("LoadTextClock");
        _timerText = GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        _timerText.text = TimerSystem.instance.timerText;
    }
}
