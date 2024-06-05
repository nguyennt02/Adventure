using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : NewMonoBehaviour
{
    [SerializeField] protected Button _button;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadButton();
    }

    protected virtual void Start()
    {
        AddOnClickEvent();
    }

    protected virtual void AddOnClickEvent()
    {
        _button.onClick.AddListener(OnClick);
    }

    protected virtual void OnClick()
    {
        AudioManager.instance.PlaySFX("Click");
    }

    protected virtual void LoadButton()
    {
        if(_button != null) return;
        LogWarning("LoadButton");
        _button = GetComponent<Button>();
    }

}
