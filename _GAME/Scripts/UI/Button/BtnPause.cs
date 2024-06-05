using UnityEngine;

public class BtnPause : BaseButton
{
    private int isPause = 0;
    protected override void OnClick()
    {
        base.OnClick();
        Time.timeScale = isPause;
        if (isPause == 0)
            isPause = 1;
        else if (isPause == 1)
            isPause = 0;
        UIManager.instance.ActiveUIGamePlay();
        UIManager.instance.DesActiveUISetting();
    }
}
