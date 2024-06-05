using UnityEngine;

public class ActiveHeart : ActivePotion
{
    [SerializeField] protected int _hp;

    protected override void Healing(CRTDamageReceiver damageReceiver)
    {
        damageReceiver.Healing(_hp);
    }
}
