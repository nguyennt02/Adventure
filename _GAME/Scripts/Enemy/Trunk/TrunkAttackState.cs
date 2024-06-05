using UnityEngine;

public class TrunkAttackState : RadishAttackState
{
    public TrunkAttackState(Enemy enemy) : base(enemy)
    {
    }

    protected override void CreateBullet()
    {
        GameObject bullet = TrunkBulletPooling.instance.GetPoolingObject();
        bullet.transform.position = _enemy.transform.position;
        bullet.transform.rotation = _enemy.transform.parent.rotation;
        bullet.SetActive(true);
    }
}
