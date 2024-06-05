using UnityEngine;

public class BtnExit : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        Application.Quit();
    }
}
