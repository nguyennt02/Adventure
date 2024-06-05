public class BtnHome : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        GameManager.instance.LoadSceneGame(0);
    }
}
