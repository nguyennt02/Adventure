using UnityEngine;

public abstract class DamageReceiver : NewMonoBehaviour
{
    [SerializeField] protected int _maxHp;
    protected int _currentHp;
    [SerializeField] protected float _timeInvincible;
    protected bool _invincible = false;

    protected virtual void Start()
    {
        _currentHp = _maxHp;
    }

    public virtual void TakeDamage(int damage)
    {
        if (damage <= 0 || _currentHp <= 0 || _invincible) return;
        _invincible = true;
        Invoke(nameof(EndInvincibility), _timeInvincible);
        _currentHp -= damage;
        if (_currentHp > 0) 
        {
            Bleed();
        }
        else 
        {
            _currentHp = 0;
            Die();
        }
    }

    protected abstract void Bleed();

    protected abstract void Die();

    protected virtual void EndInvincibility() => _invincible = false;
}
