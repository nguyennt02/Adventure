using System;
using UnityEngine;

public class Enemy : BaseEnemy
{
    [NonSerialized] public EnemyIdelState idelState;
    [NonSerialized] public EnemyFlipState flipState;
    [NonSerialized] public EnemyHitState hitState;
    [NonSerialized] public EnemyMoveState moveState;
    [NonSerialized] public EnemyMoveToPlayerState moveToPlayerState;
    [NonSerialized] public EnemyDieState dieState;
    [NonSerialized] public EnemyAttackState attackState;

    [NonSerialized] public bool isDie = false;

    //Idel State
    [Header("Idel State")]
    public float timeIdel;

    //Move State
    [Header("Move State")]
    [NonSerialized] public Transform endPoint;
    [NonSerialized] public float time;
    public Transform[] arrPoint;
    public float speed;
    public float acceleration;

    [Header("Enemy Attack State")]
    public float distance;

    [Header("Radish time Shooting")]
    public float shotTime;

    protected virtual void Start()
    {
        Contracter();
        StartState(moveState);
    }
    protected virtual void Contracter()
    {
        idelState = new EnemyIdelState(this);
        flipState = new EnemyFlipState(this);
        hitState = new EnemyHitState(this);
        moveState = new EnemyMoveState(this);
        moveToPlayerState = new EnemyMoveToPlayerState(this);
        dieState = new EnemyDieState(this);
        attackState = new EnemyAttackState(this);
    }
    public virtual void Destroy()
    {
        Destroy(transform.parent.parent.gameObject);
    }
}
