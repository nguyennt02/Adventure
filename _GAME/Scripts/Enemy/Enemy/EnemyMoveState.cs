using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected int _direction = 1;
    protected int _index = 1;

    public EnemyMoveState(Enemy enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.endPoint = _enemy.arrPoint[_index];
        _enemy.flipState.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.RUN);
    }
    public override void Update()
    {
        base.Update();
        _enemy.time += Time.deltaTime;
        Moving();
        Navigation();
    }

    protected virtual void Moving()
    {
        _enemy.transform.parent.position = Vector3.MoveTowards(
            _enemy.transform.transform.parent.position,
            _enemy.arrPoint[_index].position,
            (_enemy.acceleration / 2) * _enemy.time * _enemy.time + _enemy.speed * Time.deltaTime);
    }

    protected virtual void Navigation()
    {
        var distance = (_enemy.arrPoint[_index].position - _enemy.transform.parent.position).magnitude;
        if (distance > 0.1f) return;
        _enemy.time = 0;
        ChangeDirection();
        ChangeIndex();
        ChangeState();
    }

    protected virtual void ChangeIndex()
    {
        _index += _direction;
    }
    protected virtual void ChangeDirection()
    {
        if (isChangDirection)
            _direction *= -1;
    }
    protected virtual bool isChangDirection => _index == 0 || _index == _enemy.arrPoint.Length - 1;

    protected virtual void ChangeState()
    {
        isComplete = true;
        _enemy.ChangeState(_enemy.idelState);
    }
    public override void Exit()
    {
        base.Exit();
        isComplete = false;
    }
}
