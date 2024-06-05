
public class FlatformsCtrl : NewMonoBehaviour
{
    public AnimManager anim;
    public MoveFlatforms moveFlf;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimManager();
        LoadMoveFlatforms();
    }

    private void LoadMoveFlatforms()
    {
        if (moveFlf) return;
        LogWarning("LoadMoveFlatforms");
        moveFlf = GetComponentInChildren<MoveFlatforms>();
    }

    private void LoadAnimManager()
    {
        if (anim) return;
        LogWarning("LoadAnimManager");
        anim = GetComponentInChildren<AnimManager>();
    }
}
