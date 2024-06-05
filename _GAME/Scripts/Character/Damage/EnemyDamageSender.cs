using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagConst.ENEMY_TAG)) return;
        base.Attack(other.transform);
    }
}
