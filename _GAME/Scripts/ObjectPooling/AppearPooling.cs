public class AppearPooling : ObjectPooling
{
    private static AppearPooling _instance;
    public static AppearPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("AppearPooling already exist");        
        _instance = this;
    }
}
