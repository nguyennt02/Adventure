using UnityEngine;

public class TrunkBulletDamageSender : BulletDamageSender
{
    protected override void Despawn()
    {
        GameObject bulletPices = TrunkBulletPicesPooling.instance.GetPoolingObject();
        bulletPices.transform.position = transform.parent.position;
        bulletPices.SetActive(true);
    }
}
