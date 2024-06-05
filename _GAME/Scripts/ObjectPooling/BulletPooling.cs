public class BulletPooling : ObjectPooling
{
    private static BulletPooling _instance;
    public static BulletPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("BulletPooling already exist");
        _instance = this;
    }
}
