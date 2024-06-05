using System;
using UnityEngine;

public abstract class MoveFlatforms : NewMonoBehaviour
{
    [SerializeField] protected FlatformsCtrl _ctrl;
    [SerializeField] protected PointMove[] _arrPoint;
    [SerializeField] protected float _speed;
    [SerializeField] protected float _delay;
    [SerializeField] protected float _acceleration;

    protected int _direction = 1;
    protected int _index = 1;
    protected float _time = 0;

    protected bool _isDelay = false;

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

    protected virtual void Update()
    {
        _time += Time.deltaTime;
        Moving();
        Navigation();
    }

    protected virtual void Moving()
    {
        transform.parent.position = Vector3.MoveTowards(
            transform.parent.position,
            _arrPoint[_index].point.position,
            (_acceleration / 2) * _time * _time + _speed * Time.deltaTime);
    }

    protected virtual void Navigation()
    {
        var distance = (_arrPoint[_index].point.position - transform.parent.position).magnitude;
        if (distance > 0.1f) return;
        if (_isDelay) return;
        _isDelay = true;
        Stop();
        Invoke(nameof(Delay), _delay);
    }

    protected virtual void Stop()
    {
        if (_arrPoint[_index].stop)
            enabled = false;
    }

    protected virtual void Delay()
    {
        _isDelay = false;
        _time = 0;
        ChangePoint();
    }
    protected virtual void ChangeIndex()
    {
        _index += _direction;
    }
    protected abstract void ChangePoint();
    protected virtual void OnEnable()
    {
        _ctrl.anim.ChangeState(ANIMSTATE.ON);
    }
    protected virtual void OnDisable()
    {
        _ctrl.anim.ChangeState(ANIMSTATE.OFF);
    }
}
[Serializable]
public class PointMove
{
    public Transform point;
    public bool stop;
}
