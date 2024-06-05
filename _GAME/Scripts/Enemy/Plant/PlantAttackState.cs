using UnityEngine;

public class PlantAttackState : PlanState
{
    public PlantAttackState(Plant enemy) : base(enemy)
    {
    }
    protected float _time;
    public override void Enter()
    {
        base.Enter();
        _enemy.anim.ChangeState(ENEMYSTATE.ATTACK);
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
        GameObject bullet = BulletPooling.instance.GetPoolingObject();
        bullet.transform.position = _enemy.transform.position;
        bullet.transform.rotation = _enemy.transform.parent.rotation;
        bullet.SetActive(true);
    }
}
