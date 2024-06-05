using UnityEngine;

public class EnemyHitState : EnemyState
{
    public EnemyHitState(Enemy enemy) : base(enemy)
    {
    }
    protected float _time;
    public override void Enter()
    {
        base.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.HIT);
       
    }
    public override void Update()
    {
        base.Update();
        _time += Time.deltaTime;
        if (_time < 0.2f) return;
        ChangeState();
    }

    protected virtual void ChangeState()
    {
        isComplete = true;
        _enemy.ChangeState(_enemy.moveState);
    }

    public override void Exit()
    {
        base.Exit();
        isComplete = false;
        _time = 0;
    }
}
