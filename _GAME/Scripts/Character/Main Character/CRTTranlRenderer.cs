using UnityEngine;

[RequireComponent (typeof(TrailRenderer))]
public class CRTTranlRenderer : NewMonoBehaviour
{
    [SerializeField] protected TrailRenderer _trailRen;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadTrailRenderer();
    }

    protected virtual void LoadTrailRenderer()
    {
        if (_trailRen) return;
        LogWarning("LoadTrailRenderer");
        _trailRen = GetComponent<TrailRenderer>();
    }
    public virtual void Emitting(bool emitting)
    {
        _trailRen.emitting = emitting;
    }
}
