public class BeeBulletPooling : ObjectPooling
{
    private static BeeBulletPooling _instance;
    public static BeeBulletPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("BeeBulletPooling already exist");
        _instance = this;
    }
}
