using UnityEngine;

[RequireComponent (typeof(Animator))]
public class AnimManager : NewMonoBehaviour
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
    public void ChangeState(ANIMSTATE state)
    {
        _anim.SetInteger(AnimConst.STATE_KEY, (int)state);
    }
}
public enum ANIMSTATE
{
    OFF = 0,
    ON = 1
}
