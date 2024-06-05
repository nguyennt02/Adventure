using UnityEngine;

public class CRTDamageReceiver : DamageReceiver
{
    public virtual int maxHp => _maxHp;
    public virtual int currentHp => _currentHp;
    protected override void Start()
    {
        _maxHp = PlayerPrefs.GetInt(PlayerPrefsConst.MAX_HP_PP, _maxHp);
        _currentHp = PlayerPrefs.GetInt(PlayerPrefsConst.CURRENT_HP_PP, _currentHp);
        UIHeartOsv.CreatUIHeart?.Invoke(_maxHp);
        UIHeartOsv.UpdateHp?.Invoke(_currentHp);
    }

    protected override void Bleed()
    {
        Desappearing();
        Deactivate();
        AudioManager.instance.PlaySFX("Die");
        UIHeartOsv.UpdateHp?.Invoke(_currentHp);
        CheckPonitManager.instance.Revival();
    }

    protected override void Die()
    {
        UIHeartOsv.UpdateHp?.Invoke(_currentHp);
        GameManager.instance.GameOver();
    }

    protected virtual void Desappearing()
    {
        GameObject desappear = DesappearPooling.instance.GetPoolingObject();
        desappear.transform.position = transform.parent.position;
        desappear.SetActive(true);       
    }
    protected virtual void Deactivate()
    {
        transform.parent.gameObject.SetActive(false);
    }
    public virtual void Healing(int hp)
    {
        if (hp <= 0) return;
        _currentHp += hp;
        if (_currentHp > _maxHp)
        {
            int newHp = _currentHp - _maxHp;
            _maxHp = _currentHp;
            UIHeartOsv.CreatUIHeart?.Invoke(newHp);
        }
        UIHeartOsv.UpdateHp?.Invoke(_currentHp);
    }
    public virtual void FullBlood()
    {
        if (_currentHp < _maxHp)
            _currentHp = _maxHp;
        UIHeartOsv.UpdateHp?.Invoke(_currentHp);
    }
}
