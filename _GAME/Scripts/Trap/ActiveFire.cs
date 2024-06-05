using UnityEngine;

public class ActiveFire : NewMonoBehaviour
{
    [SerializeField] protected AnimManager _anim;
    [SerializeField] protected float _timeFire;
    protected bool _isActive = false;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimManager();
    }

    protected virtual void LoadAnimManager()
    {
        if (_anim) return;
        LogWarning("LoadAnimManager");
        _anim = GetComponentInParent<AnimManager>();
    }
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || _isActive) return;
        _isActive = true;
        StartFire();
        Invoke(nameof(EndFire), _timeFire);
    }
    protected virtual void StartFire()
    {
        AudioManager.instance.PlaySFX("Fire");
        _anim.ChangeState(ANIMSTATE.ON);
    }
    protected virtual void EndFire()
    {
        _isActive = false;
        AudioManager.instance.StopSFX();
        _anim.ChangeState(ANIMSTATE.OFF);
    }
}
