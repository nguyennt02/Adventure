public class BulletLeafsPooling : ObjectPooling
{
    private static BulletLeafsPooling _instance;
    public static BulletLeafsPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("BulletLeafsPooling already exist");
        _instance = this;
    }
}
