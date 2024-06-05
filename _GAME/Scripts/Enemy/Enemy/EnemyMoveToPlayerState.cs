using UnityEngine;

public class EnemyMoveToPlayerState : EnemyState
{
    public EnemyMoveToPlayerState(Enemy enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.flipState.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.RUN);
    }
    public override void Update()
    {
        base.Update();
        _enemy.time += Time.deltaTime;
        Moving();
        ChangeState();
    }
    public override void Exit()
    {
        base.Exit();
        _enemy.time = 0;
        isComplete = false;
    }
    protected virtual void Moving()
    {
        _enemy.transform.parent.position = Vector3.MoveTowards(
            _enemy.transform.transform.parent.position,
            _enemy.endPoint.position,
            (_enemy.acceleration / 2) * _enemy.time * _enemy.time + _enemy.speed * Time.deltaTime);
    }
    protected virtual void ChangeState()
    {
        float distance = (_enemy.transform.parent.position - _enemy.endPoint.position).magnitude;
        if (distance > _enemy.distance) return;
        isComplete = true;
        _enemy.ChangeState(_enemy.attackState);
    }
}
