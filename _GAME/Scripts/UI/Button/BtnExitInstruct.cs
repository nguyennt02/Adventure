public class BtnExitInstruct : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UIStartManager.instance.ActiveUIGameStart();
        UIStartManager.instance.DesActiveUIInstruct();
    }
}
