public class BtnInstruct : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UIStartManager.instance.DesActiveUIGameStart();
        UIStartManager.instance.ActiveUIInstruct();
    }
}
