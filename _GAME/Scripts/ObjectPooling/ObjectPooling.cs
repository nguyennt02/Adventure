using System;
using System.Collections.Generic;
using UnityEngine;
public abstract class ObjectPooling : NewMonoBehaviour
{
    [SerializeField] protected GameObject _poolObject;
    [SerializeField] protected List<GameObject> _lstPoolObject;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadPoolObject();
    }

    protected virtual void LoadPoolObject()
    {
        if (_poolObject) return;
        LogWarning("LoadPoolObject");
        _poolObject = transform.GetChild(0).gameObject; 
    }

    public virtual GameObject GetPoolingObject()
    {
        foreach (var obj in _lstPoolObject)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return AddAndGetObject();
    }

    protected virtual GameObject AddAndGetObject()
    {
        GameObject obj = Instantiate(_poolObject, gameObject.transform);
        obj.SetActive(false);
        _lstPoolObject.Add(obj);
        return obj;
    }
    public virtual void ClearPoolingObject()
    {
        foreach (var obj in _lstPoolObject)
        {
            obj.SetActive(false);
        }
    }
    public virtual void AddObject(GameObject gameObject)
    {
        GameObject obj = _lstPoolObject.Find(x => x == gameObject);
        if(!obj) _lstPoolObject.Add(gameObject);
    }
}
