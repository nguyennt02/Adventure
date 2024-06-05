using UnityEngine;

public class CollectedPooling : ObjectPooling
{
    private static CollectedPooling _instance;
    public static CollectedPooling instance => _instance;
    protected override void Awake()
    {
        base.Awake();
        LoadInstance();
    }

    private void LoadInstance()
    {
        if (_instance) LogError("CollectedPooling already exist");
        _instance = this;
    }
}
