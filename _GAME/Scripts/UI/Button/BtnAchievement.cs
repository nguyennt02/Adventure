public class BtnAchievement : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UIStartManager.instance.DesActiveUIGameStart();
        UIStartManager.instance.ActiveUIAchievement();
    }
}
