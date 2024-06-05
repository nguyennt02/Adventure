using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CRTDamageSender : DamageSender
{
    [SerializeField] protected CharacterCtrl _ctrl;
    [SerializeField] protected float _force;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCharacterCtrl();
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (_ctrl) return;
        LogWarning("LoadCharacterCtrl");
        _ctrl = GetComponentInParent<CharacterCtrl>();
    }
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(TagConst.PLAYER_TAG)) return;
        base.OnTriggerEnter2D(other);
    }
    protected override void Attack(DamageReceiver damageReceiver)
    {
        base.Attack(damageReceiver);
        AudioManager.instance.PlaySFX("Attack");
        Jet();
    }
    protected virtual void Jet()
    {
        _ctrl.cMov.SetFrameVelocity(Vector2.up * _force);
    }
}
