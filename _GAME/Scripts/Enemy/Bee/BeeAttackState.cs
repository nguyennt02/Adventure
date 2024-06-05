using UnityEngine;

public class BeeAttackState : BeeState
{
    public BeeAttackState(Bee enemy) : base(enemy)
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
        // Xoay mượt mà tới quaternion mới
        _enemy.transform.parent.rotation = Quaternion.Slerp(
            _enemy.transform.parent.rotation,
            Rotation(),
            Time.deltaTime * _enemy.speedRotation);
        Shooting();
    }

    protected virtual Quaternion Rotation()
    {
        Vector3 vectorTarget = (_enemy.target.position - _enemy.transform.parent.position).normalized;
        // Tính góc giữa vectorA và vectorB
        float angle = Vector3.Angle(Vector3.down, vectorTarget);
        angle = Mathf.Clamp(angle, 0, 60);
        // Tính vector pháp tuyến của vectorA và vectorB
        Vector3 crossProduct = Vector3.Cross(Vector3.down, vectorTarget);

        Quaternion rotation = Quaternion.AngleAxis(angle, crossProduct);
        return rotation;
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
        GameObject bullet = BeeBulletPooling.instance.GetPoolingObject();
        bullet.transform.position = _enemy.transform.position;
        bullet.transform.rotation = _enemy.transform.parent.rotation;
        bullet.SetActive(true);
    }
}
