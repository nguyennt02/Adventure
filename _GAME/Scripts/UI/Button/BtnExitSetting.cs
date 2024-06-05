using UnityEngine;

public class BtnExitSetting : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UIManager.instance.DesActiveUISetting();
        UIManager.instance.ActiveUIGamePlay();
    }
}
