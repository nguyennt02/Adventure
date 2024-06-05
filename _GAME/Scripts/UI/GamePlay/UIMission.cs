using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIMission : NewMonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _txtMission;
    [SerializeField] private Image _imgMission;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadText();
        LoadImage();
    }

    private void LoadImage()
    {
        if (_imgMission) return;
        LogWarning("LoadImage");
        _imgMission = GetComponentInChildren<Image>();
    }

    private void LoadText()
    {
        if (_txtMission) return;
        LogWarning("LoadText");
        _txtMission = GetComponentInChildren<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        UIMissionOsv.UpdateMission += UpdateMission;
    }
    private void OnDisable()
    {
        UIMissionOsv.UpdateMission -= UpdateMission;
    }
    private void UpdateMission(Sprite mission, int maxQuantity, int quantity, Vector2 size)
    {
        _imgMission.sprite = mission;
        _imgMission.rectTransform.sizeDelta = size;
        _txtMission.text = $"{quantity}/{maxQuantity}";
    }
}
public static class UIMissionOsv
{
    public static Action<Sprite, int, int, Vector2> UpdateMission;
}
