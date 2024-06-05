using UnityEngine;

public class ActivePotion : NewMonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG)) return;
        Healing(other.transform);
        transform.parent.gameObject.SetActive(false);
    }

    protected virtual void Healing(Transform other)
    {
        CRTDamageReceiver damageReceiver = other.GetComponent<CRTDamageReceiver>();
        if (damageReceiver)
        {
            AudioManager.instance.PlaySFX("ItemPickUp");
            Healing(damageReceiver);
        }

    }
    protected virtual void Healing(CRTDamageReceiver damageReceiver)
    {
        damageReceiver.FullBlood();
    }
}
