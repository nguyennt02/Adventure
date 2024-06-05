using System;
using UnityEngine;

public class LoadGame : NewMonoBehaviour
{
    [SerializeField] Animator _anim;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadAnimator();
    }

    private void LoadAnimator()
    {
        if (_anim) return;
        Log("LoadAnimator");
        _anim = GetComponent<Animator>();
    }
    private void Start()
    {
        _anim.updateMode = AnimatorUpdateMode.UnscaledTime;
    }
}
