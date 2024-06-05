using System.Collections;
using UnityEngine;

public class DespawnByTime : NewMonoBehaviour
{
    [SerializeField] protected float _timeLife;

    protected float _time;
    protected virtual void OnEnable()
    {
        _time = 0;
    }
    protected virtual void Update()
    {
        _time += Time.deltaTime;
        if (_time < _timeLife) return;
        Despawning();
    }

    protected virtual void Despawning()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
