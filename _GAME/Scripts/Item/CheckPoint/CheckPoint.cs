using UnityEngine;

public class CheckPoint : NewMonoBehaviour
{
    [SerializeField] protected AnimManager _animManager;
    [SerializeField] protected Transform _point;
    protected bool isOn = false;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimManager();
        LoadPoint();
    }

    protected virtual void LoadPoint()
    {
        if (_point) return;
        LogWarning("LoadPoint");
        _point = transform.GetChild(0);
    }

    protected virtual void LoadAnimManager()
    {
        if (_animManager) return;
        LogWarning("LoadAnimManager");
        _animManager = transform.parent.GetComponentInChildren<AnimManager>();
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) || isOn) return;
        isOn = true;
        _animManager.ChangeState(ANIMSTATE.ON);
        CheckPonitManager.instance.ChangePoint((Vector2)_point.position);
        AudioManager.instance.PlaySFX("CollectPoint");
    }
}
