using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UIManager.instance.DesActiveUIGamePLay();
        UIManager.instance.ActiveUISetting();
    }
}
