using UnityEngine;

public class BulletDamageSender : EnemyDamageSender
{
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagConst.ENEMY_TAG) || other.isTrigger) return;
        base.Attack(other.transform);
        Despawn();
        transform.parent.gameObject.SetActive(false);
    }
    protected virtual void Despawn()
    {
        GameObject bulletPices = BulletPicesPooling.instance.GetPoolingObject();
        bulletPices.transform.position = transform.parent.position;
        bulletPices.SetActive(true);
    }
}
