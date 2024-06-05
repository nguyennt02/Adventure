using UnityEngine;

public class BeeBulletDamageSender : BulletDamageSender
{
    protected override void Despawn()
    {
        GameObject bulletPices = BeeBulletPicesPooling.instance.GetPoolingObject();
        bulletPices.transform.position = transform.parent.position;
        bulletPices.SetActive(true);
    }
}
