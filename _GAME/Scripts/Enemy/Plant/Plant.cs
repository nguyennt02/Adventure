using System;
using UnityEngine;

public class Plant : BaseEnemy
{
    [NonSerialized] public PlantIdelState idelState;
    [NonSerialized] public PlantHitState hitState;
    [NonSerialized] public PlantDieState dieState;
    [NonSerialized] public PlantAttackState attackState;

    [NonSerialized] public bool isDie = false;

    //Attack State
    public float shotTime;

    protected virtual void Start()
    {
        Contracter();
        StartState(idelState);
    }
    protected virtual void Contracter()
    {
        idelState = new PlantIdelState(this);
        hitState = new PlantHitState(this);
        dieState = new PlantDieState(this);
        attackState = new PlantAttackState(this);
    }
    public virtual void Destroy()
    {
        Destroy(transform.parent.gameObject);
    }
}
