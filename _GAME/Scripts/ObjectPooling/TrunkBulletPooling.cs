public class TrunkBulletPooling : ObjectPooling
{
    private static TrunkBulletPooling _instance;
    public static TrunkBulletPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("TrunkBulletPooling already exist");
        _instance = this;
    }
}
