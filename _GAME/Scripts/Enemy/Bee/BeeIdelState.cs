using UnityEngine;

public class BeeIdelState : BeeState
{
    public BeeIdelState(Bee enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.IDEL);
    }
    public override void Update()
    {
        // Xoay mượt mà tới quaternion mới
        _enemy.transform.parent.rotation = Quaternion.Slerp(
            _enemy.transform.parent.rotation,
            Quaternion.Euler(0, 0, 0),
            Time.deltaTime * _enemy.speedRotation);
    }
}
