using UnityEngine;

public class DamageSender : NewMonoBehaviour
{
    [SerializeField] protected int _damage;
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        Attack(other.transform);
    }

    protected virtual void Attack(Transform other)
    {
        DamageReceiver damageReceiver = other.GetComponent<DamageReceiver>();
        if(damageReceiver)
            Attack(damageReceiver);
    }
    protected virtual void Attack(DamageReceiver damageReceiver)
    {
        damageReceiver.TakeDamage(_damage);
    }
}
