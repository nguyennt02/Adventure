using UnityEngine;

public class DespawnBreak : NewMonoBehaviour
{
    [SerializeField] protected float _timeLife;
    protected virtual void OnEnable()
    {
        Invoke(nameof(Despawning), _timeLife);
        OnActiveFragments();
    }
    protected virtual void Despawning()
    {
        transform.gameObject.SetActive(false);
    }
    protected virtual void OnActiveFragments()
    {
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }
}
