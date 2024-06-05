public class BtnExitAchievement : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        UIStartManager.instance.ActiveUIGameStart();
        UIStartManager.instance.DesActiveUIAchievement();
    }
}
