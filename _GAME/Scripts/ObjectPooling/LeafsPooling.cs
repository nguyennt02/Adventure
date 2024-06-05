public class LeafsPooling : ObjectPooling
{
    private static LeafsPooling _instance;
    public static LeafsPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("LeafsPooling already exist");
        _instance = this;
    }
}
