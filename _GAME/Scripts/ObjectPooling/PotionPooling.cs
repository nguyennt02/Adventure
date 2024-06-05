public class PotionPooling : ObjectPooling
{
    private static PotionPooling _instance;
    public static PotionPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("PotionPooling already exist");
        _instance = this;
    }
}
