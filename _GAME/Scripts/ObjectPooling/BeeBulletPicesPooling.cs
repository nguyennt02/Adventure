public class BeeBulletPicesPooling : ObjectPooling
{
    private static BeeBulletPicesPooling _instance;
    public static BeeBulletPicesPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("BeeBulletPicesPooling already exist");
        _instance = this;
    }
}
