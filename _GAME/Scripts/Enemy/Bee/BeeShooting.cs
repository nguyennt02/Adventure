using UnityEngine;

public class BeeShooting : NewMonoBehaviour
{
    [SerializeField] protected Bee _enemy;
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
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || _enemy.isDie) return;
        _enemy.target = other.transform.parent;
        _enemy.ChangeState(_enemy.attackState);
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || _enemy.isDie) return;
        _enemy.ChangeState(_enemy.idelState);
    }
}
