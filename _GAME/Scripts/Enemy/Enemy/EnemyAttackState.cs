using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy) : base(enemy)
    {
    }
    protected float _time;
    public override void Enter()
    {
        base.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.ATTACK);
    }
    public override void Update()
    {
        base.Update();
        _time += Time.deltaTime;
        if (_time < 0.4f) return;
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
