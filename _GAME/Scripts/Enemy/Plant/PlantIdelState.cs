using UnityEngine;

public class PlantIdelState : PlanState
{
    public PlantIdelState(Plant enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.IDEL);
    }
}
