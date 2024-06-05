using UnityEngine;

public class BeeDieState : BeeState
{
    public BeeDieState(Bee enemy) : base(enemy)
    {
    }

    protected float _time;
    public override void Enter()
    {
        base.Enter();
        _enemy.isDie = true;
        _enemy.anim.ChangeState(ENEMYSTATE.DIE);
    }
    public override void Update()
    {
        base.Update();
        _time += Time.deltaTime;
        if (_time < 1f) return;
        DestroyEnemy();
    }
    protected virtual void DestroyEnemy()
    {
        isComplete = true;
        _enemy.Destroy();
    }
    public override void Exit()
    {
        base.Exit();
        isComplete = false;
        _time = 0;
    }
}
