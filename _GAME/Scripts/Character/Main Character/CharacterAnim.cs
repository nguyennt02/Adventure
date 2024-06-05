using UnityEngine;

[RequireComponent (typeof(Animator))]
public class CharacterAnim : NewMonoBehaviour
{
    [SerializeField] protected Animator _anim;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (_anim) return;
        LogWarning("LoadAnimator");
        _anim = GetComponent<Animator>();
    }
    public virtual void SetyVelocity(float yVelocity)
    {
        _anim.SetFloat(AnimConst.YVELOCITY_KEY, yVelocity);
    }
    public virtual void SetCRTState(CRTSTATE CRTSTATE)
    {
        _anim.SetInteger(AnimConst.STATE_KEY,(int)CRTSTATE);
    }
}

public enum CRTSTATE
{
    IDEL = 0,
    RUN = 1,
    OVERHEAD = 2,
    HOLD = 3
}