using UnityEngine;

public class ActiveTramPoline : NewMonoBehaviour
{
    [SerializeField] protected AnimManager _anim;
    [SerializeField] protected float _force;
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

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(TagConst.PLAYER_TAG)) return;
        _anim.ChangeState(ANIMSTATE.ON);
        AddForce(other.transform.parent);
    }

    protected virtual void AddForce(Transform player)
    {
        CharacterCtrl ctrl = player.GetComponent<CharacterCtrl>();
        AddForce(ctrl.cMov);
    }
    protected virtual void AddForce(CharacterMovement player)
    {
        player.SetFrameVelocity(Direction() * _force);
    }

    protected virtual Vector2 Direction()
    {
        // Lấy góc quay từ thành phần Z của Quaternion
        float angleInDegrees = transform.parent.rotation.eulerAngles.z;

        // Chuyển đổi góc từ độ sang radian
        float angleInRadians = angleInDegrees * Mathf.Deg2Rad;

        // Tạo quaternion từ góc xoay
        Quaternion rotation = Quaternion.Euler(0, 0, angleInDegrees);

        // Xoay vector
        Vector2 rotatedVector = rotation * Vector2.up;
        return rotatedVector;
    }
}
