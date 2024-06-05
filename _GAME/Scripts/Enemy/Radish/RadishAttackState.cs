using UnityEngine;

public class RadishAttackState : EnemyAttackState
{
    public RadishAttackState(Enemy enemy) : base(enemy)
    {
    }
    public override void Enter()
    {
        base.Enter();
        _time = _enemy.shotTime;
    }
    public override void Update()
    {
        Shooting();
    }
    protected virtual void Shooting()
    {
        _time += Time.deltaTime;
        if (_time < _enemy.shotTime) return;
        CreateBullet();
        _time = 0;
    }
    protected virtual void CreateBullet()
    {
        GameObject bullet = BulletLeafsPooling.instance.GetPoolingObject();
        bullet.transform.position = _enemy.transform.position;
        bullet.transform.rotation = _enemy.transform.parent.rotation;
        bullet.SetActive(true);
    }
    public override void Exit()
    {
    }
}
