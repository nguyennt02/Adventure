using System;
using UnityEngine;

public class CharacterCtrl : NewMonoBehaviour
{
    public CharacterParameter pram;
    public CheckCollider cCol;
    public CharacterMovement cMov;
    public CharacterAnim anim;
    public CRTTranlRenderer cTranlRen;
    public CRTParticlesSystem cParticle;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCharacterPrameter();
        LoadCheckCollider();
        LoadCharacterMovement();
        LoadCharacterAnim();
        LoadCRTTranlRenderer();
        LoadCRTParticlesSystem();
    }

    protected virtual void LoadCRTParticlesSystem()
    {
        if (cParticle) return;
        LogWarning("LoadCRTParticlesSystem");
        cParticle = GetComponentInChildren<CRTParticlesSystem>();
    }

    protected virtual void LoadCRTTranlRenderer()
    {
        if (cTranlRen) return;
        LogWarning("LoadCRTTranlRenderer");
        cTranlRen = GetComponentInChildren<CRTTranlRenderer>();
    }

    protected virtual void LoadCharacterAnim()
    {
        if (anim) return;
        LogWarning("LoadCharacterAnim");
        anim = GetComponentInChildren<CharacterAnim>();
    }

    protected virtual void LoadCharacterMovement()
    {
        if (cMov) return;
        LogWarning("LoadCharacterMovement");
        cMov = GetComponentInChildren<CharacterMovement>();
    }

    protected virtual void LoadCheckCollider()
    {
        if (cCol) return;
        LogWarning("LoadCheckCollider");
        cCol = GetComponentInChildren<CheckCollider>();
    }

    protected virtual void LoadCharacterPrameter()
    {
        if (pram) return;
        LogWarning("LoadCharacterPrameter");
        pram = (CharacterParameter)Resources.Load("CharacterParameter/VirtualGuy");
    }
}
