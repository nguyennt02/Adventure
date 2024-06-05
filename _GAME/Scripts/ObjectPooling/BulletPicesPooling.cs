public class BulletPicesPooling : ObjectPooling
{
    private static BulletPicesPooling _instance;
    public static BulletPicesPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("BulletPicesPooling already exist");
        _instance = this;
    }
}
