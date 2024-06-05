using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class EnemyFlipState : EnemyState
{
    protected bool _isFacingRight = false;
    public EnemyFlipState(Enemy enemy) : base(enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Flip();
        isComplete = true;
    }

    protected virtual void Flip()
    {
        bool isFacingRight = _enemy.transform.parent.position.x < _enemy.endPoint.position.x;
        if (isFacingRight && !_isFacingRight)
            FlipFacing(180);
        else if(!isFacingRight && _isFacingRight)
            FlipFacing(0);
    }

    protected virtual void FlipFacing(float y)
    {
        _isFacingRight = !_isFacingRight;
        Vector3 currentRotation = _enemy.transform.parent.eulerAngles;
        currentRotation.y = y;
        _enemy.transform.parent.eulerAngles = currentRotation;
    }
    public override void Exit()
    {
        base.Exit();
        isComplete = false;
    }
}
