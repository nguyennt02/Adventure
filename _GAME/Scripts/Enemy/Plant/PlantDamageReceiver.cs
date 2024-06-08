using UnityEngine;

public class PlantDamageReceiver : DamageReceiver
{
    [SerializeField] protected Plant _enemy;
    protected ENEMYS _enemys = ENEMYS.PLANT;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadEnemy();
    }

    protected virtual void LoadEnemy()
    {
        if (_enemy) return;
        LogWarning("LoadEnemy");
        _enemy = transform.parent.GetComponentInChildren<Plant>();
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
