public class EnemyAnimManager : AnimManager
{
    public void ChangeState(ENEMYSTATE state)
    {
        _anim.SetInteger(AnimConst.STATE_KEY, (int)state);
    }
}
public enum ENEMYSTATE
{
    IDEL = 0,
    RUN = 1,
    HIT = 2,
    ATTACK = 3,
    DIE = 4
}
