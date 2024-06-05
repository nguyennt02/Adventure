using System;
using UnityEngine;

public class FlatformsActiveMove : NewMonoBehaviour
{
    [SerializeField] protected FlatformsCtrl _ctrl;
    [SerializeField] protected float _delayTime;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadFlatformsCtrl();
    }

    protected virtual void LoadFlatformsCtrl()
    {
        if (_ctrl) return;
        LogWarning("LoadFlatformsCtrl");
        _ctrl = GetComponentInParent<FlatformsCtrl>();
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || other.isTrigger) return;
        Invoke(nameof(ActiveMove), _delayTime);
    }
    protected virtual void ActiveMove()
    {
        _ctrl.moveFlf.enabled = true;
    }
}
