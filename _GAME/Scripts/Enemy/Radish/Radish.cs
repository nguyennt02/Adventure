public class Radish : Enemy
{
    protected override void Contracter()
    {
        idelState = new EnemyIdelState(this);
        flipState = new EnemyFlipState(this);
        hitState = new EnemyHitState(this);
        moveState = new EnemyMoveState(this);
        moveToPlayerState = new EnemyMoveToPlayerState(this);
        dieState = new EnemyDieState(this);
        attackState = new RadishAttackState(this);
    }
}
