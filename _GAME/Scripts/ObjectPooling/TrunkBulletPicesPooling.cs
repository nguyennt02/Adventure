public class TrunkBulletPicesPooling : ObjectPooling
{
    private static TrunkBulletPicesPooling _instance;
    public static TrunkBulletPicesPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("TrunkBulletPicesPooling already exist");
        _instance = this;
    }
}
