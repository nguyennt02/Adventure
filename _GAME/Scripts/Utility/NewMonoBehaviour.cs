using UnityEngine;

public class NewMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        LoadComponent();
        LoadValues();
    }

    protected virtual void Reset()
    {
        LoadComponent();
        LoadValues();
    }

    protected virtual void LoadValues() {}

    protected virtual void LoadComponent() {}

    protected virtual void Log(string mess)
    {
        Debug.Log($"{mess} : {GetType().Name}", gameObject);
    }

    protected virtual void LogWarning(string mess)
    {
        Debug.LogWarning($"{mess} : {GetType().Name}", gameObject);
    }

    protected virtual void LogError(string mess)
    {
        Debug.LogError($"{mess} : {GetType().Name}", gameObject);
    }
}
