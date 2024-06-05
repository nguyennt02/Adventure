using UnityEngine;

public class ChangeDirection : NewMonoBehaviour
{
    protected bool _isFacingRight = true;
    protected virtual void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG) ||
            !InputWindows.instance.KeyE()) 
            return;
        Turning(other.transform.parent);
    }
    protected virtual void Turning(Transform other)
    {
        bool isFacingRight = transform.parent.position.x < other.position.x;
        if (isFacingRight && !_isFacingRight ||
            !isFacingRight && _isFacingRight)
            Facing();
    }
    protected virtual void Facing()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.parent.localScale;
        localScale.x *= -1;
        transform.parent.localScale = localScale;
    }
}
