public class DesappearPooling : ObjectPooling
{
    private static DesappearPooling _instance;
    public static DesappearPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("DesappearPooling already exist"); 
        _instance = this;
    }
}
