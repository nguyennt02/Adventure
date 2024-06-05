using UnityEngine;

public class EnemyDamgeReceiver : DamageReceiver
{
    [SerializeField] protected Enemy _enemy;
    [SerializeField] protected ENEMYS _enemys;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadEnemy();
    }

    protected virtual void LoadEnemy()
    {
        if (_enemy) return;
        LogWarning("LoadEnemy");
        _enemy = transform.parent.GetComponentInChildren<Enemy>();
    }

    protected override void Bleed()
    {
        _enemy.ChangeState(_enemy.hitState);
    }

    protected override void Die()
    {
        MissionEnemyManager.instance.PickUpFruit(_enemys);
        _enemy.ChangeState(_enemy.dieState);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.collider.CompareTag(TagConst.PLAYER_TAG) || _invincible) return;
        _enemy.ChangeState(_enemy.idelState);
    }
}
