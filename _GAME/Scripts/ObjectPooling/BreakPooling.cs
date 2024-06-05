public class BreakPooling : ObjectPooling
{
    private static BreakPooling _instance;
    public static BreakPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("BreakPooling already exist");
        _instance = this;
    }
}
