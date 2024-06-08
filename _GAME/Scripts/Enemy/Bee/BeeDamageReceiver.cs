using UnityEngine;

public class BeeDamageReceiver : DamageReceiver
{
    [SerializeField] protected Bee _enemy;
    protected ENEMYS _enemys = ENEMYS.BEE;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadEnemy();
    }

    protected virtual void LoadEnemy()
    {
        if (_enemy) return;
        LogWarning("LoadEnemy");
        _enemy = transform.parent.GetComponentInChildren<Bee>();
    }

    protected override void Bleed()
    {
        _enemy.ChangeState(_enemy.hitState);
    }

    protected override void Die()
    {
        MissionEnemyManager.instance?.PickUpFruit(_enemys);
        _enemy.ChangeState(_enemy.dieState);
    }
}
