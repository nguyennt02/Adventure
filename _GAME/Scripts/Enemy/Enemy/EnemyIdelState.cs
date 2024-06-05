using UnityEngine;
public class EnemyIdelState : EnemyState
{
    public EnemyIdelState(Enemy enemy) : base(enemy)
    {
    }

    protected float _time;

    public override void Enter()
    {
        base.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.IDEL);
    }
    public override void Update()
    {
        base.Update();
        _time += Time.deltaTime;
        if (_time < _enemy.timeIdel) return;
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
        _time = 0;
        isComplete = false;
    }
}
