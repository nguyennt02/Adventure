using System;
using UnityEngine;

public class Bee : BaseEnemy
{
    [NonSerialized] public BeeIdelState idelState;
    [NonSerialized] public BeeHitState hitState;
    [NonSerialized] public BeeDieState dieState;
    [NonSerialized] public BeeAttackState attackState;

    //Attack State
    public float shotTime;
    public float speedRotation;
    [NonSerialized] public Transform target;
    [NonSerialized] public bool isDie = false;

    protected virtual void Start()
    {
        Contracter();
        StartState(idelState);
    }
    protected virtual void Contracter()
    {
        idelState = new BeeIdelState(this);
        hitState = new BeeHitState(this);
        dieState = new BeeDieState(this);
        attackState = new BeeAttackState(this);
    }
    public virtual void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
