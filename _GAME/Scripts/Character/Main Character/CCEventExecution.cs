using System;

public class CCEventExecution : NewMonoBehaviour
{
    protected virtual void OnEnable()
    {
        CheckColliderEven.GroundHit += GroundHit;
        CheckColliderEven.GroundOut += GroundOut;
        CheckColliderEven.WallHit += WallHit;
        CheckColliderEven.WallOut += WallOut;
        CheckColliderEven.CeilingHit += CeilingHit;
    }

    protected virtual void OnDisable()
    {
        CheckColliderEven.GroundHit -= GroundHit;
        CheckColliderEven.GroundOut -= GroundOut;
        CheckColliderEven.WallHit -= WallHit;
        CheckColliderEven.WallOut -= WallOut;
        CheckColliderEven.CeilingHit -= CeilingHit;
    }

    protected virtual void WallOut(){}

    protected virtual void WallHit(){}

    protected virtual void GroundOut(){}

    protected virtual void GroundHit(){}
    protected virtual void CeilingHit() { }
}
