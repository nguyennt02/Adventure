public class HeartPooling : ObjectPooling
{
    private static HeartPooling _instance;
    public static HeartPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("HeartPooling already exist");
        _instance = this;
    }
}
