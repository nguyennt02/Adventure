using UnityEngine;

public class Box : DamageReceiver
{
    [SerializeField] protected HEALTH _health;
    [SerializeField] protected AnimManager _anim;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimManager();
    }

    protected virtual void LoadAnimManager()
    {
        if (_anim) return;
        LogWarning("LoadAnimManager");
        _anim = transform.parent.GetComponentInChildren<AnimManager>();
    }
    protected override void Bleed()
    {
        _anim.ChangeState(ANIMSTATE.ON);
    }

    protected override void Die()
    {
        AudioManager.instance.PlaySFX("Impact");
        BoxBreak();
        DroppedItems();
        Destroy(transform.parent.gameObject);
    }
    protected virtual void BoxBreak()
    {
        GameObject boxBreak = BreakPooling.instance.GetPoolingObject();
        boxBreak.transform.position = transform.parent.position;
        boxBreak.SetActive(true);
    }
    protected virtual GameObject SelectItems()
    {
        switch (_health)
        {
            case HEALTH.HEART:
                return HeartPooling.instance.GetPoolingObject();
            case HEALTH.POTION:
                return PotionPooling.instance.GetPoolingObject();
            default:
                return null;
        }
    }
    protected virtual void DroppedItems() 
    {
        GameObject item = SelectItems();
        if (!item) return;
        item.transform.position = transform.parent.position;
        item.SetActive(true);
    }
}
public enum HEALTH
{
    NONE,
    HEART,
    POTION
}
