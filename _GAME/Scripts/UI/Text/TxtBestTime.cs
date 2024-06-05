using System;
using TMPro;
using UnityEngine;

public class TxtBestTime : NewMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
    }

    private void LoadText()
    {
        if (_text != null) return;
        LogWarning("LoadText");
        _text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        ShowBestTime();
    }

    private void ShowBestTime()
    {
        float elapsedTime = PlayerPrefs.GetFloat(PlayerPrefsConst.BEST_TIMER_PP, 1f);
        int hours = Mathf.FloorToInt(elapsedTime / 3600F);
        int minutes = Mathf.FloorToInt((elapsedTime % 3600F) / 60F);
        int seconds = Mathf.FloorToInt(elapsedTime % 60F);

        if (hours == 0) _text.text = $"{minutes:00}:{seconds:00}";
        else _text.text = $"{hours:00}:{minutes:00}:{seconds:00}";
    }
}
