using UnityEngine;

public class BtnResetMap : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        GameManager.instance.LoadCurrentMap();
    }
}
