public class BtnResetGame : BaseButton
{
    protected override void OnClick()
    {
        base.OnClick();
        GameManager.instance.LoadSceneGame(1);
    }
}
