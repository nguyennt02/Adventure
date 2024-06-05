using UnityEngine;

public class EnemyAttack : NewMonoBehaviour
{
    [SerializeField] protected Enemy _enemy;
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
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || _enemy.isDie) return;
        _enemy.endPoint = other.transform.parent;
        _enemy.ChangeState(_enemy.moveToPlayerState);
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || _enemy.isDie) return;
        _enemy.ChangeState(_enemy.moveState);
    }
}
