using UnityEngine;

public class RadishBulletDamageSender : BulletDamageSender
{
    protected override void Despawn()
    {
        GameObject bulletPices = LeafsPooling.instance.GetPoolingObject();
        bulletPices.transform.position = transform.parent.position;
        bulletPices.SetActive(true);
    }
}
