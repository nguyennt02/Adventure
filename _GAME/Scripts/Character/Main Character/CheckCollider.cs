using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class CheckCollider : NewMonoBehaviour
{
    [SerializeField] protected CapsuleCollider2D _col;
    [SerializeField] protected CharacterCtrl _ctrl;

    protected bool _grounded;
    public bool grounded { get => _grounded; }

    protected bool _walled;
    public bool walled { get => _walled; }

    protected bool _cachedQueryStartInColliders;

    protected override void Awake()
    {
        base.Awake();
        _cachedQueryStartInColliders = Physics2D.queriesStartInColliders;
    }

    protected virtual void Unit()
    {
        if (_grounded) Log("ground hit");
        else Log("ground out");
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCapsuleCollider2D();
        LoadCharacterCtrl();
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (_ctrl) return;
        LogWarning("LoadCharacterCtrl");
        _ctrl = GetComponentInParent<CharacterCtrl>();
    }

    protected virtual void LoadCapsuleCollider2D()
    {
        if (_col) return;
        LogWarning("LoadCapsuleCollider2D");
        _col = GetComponentInParent<CapsuleCollider2D>();
    }

    protected virtual void Update()
    {
        Physics2D.queriesStartInColliders = false;
        CheckGround();
        CheckWall();
        Physics2D.queriesStartInColliders = _cachedQueryStartInColliders;
    }

    protected virtual void CheckGround()
    {
        // Ground and Ceiling
        RaycastHit2D groundHit = Physics2D.CapsuleCast(_col.bounds.center, _col.size, _col.direction, 0, Vector2.down, _ctrl.pram.GrounderDistance, ~_ctrl.pram.PlayerLayer);
        RaycastHit2D ceilingHit = Physics2D.CapsuleCast(_col.bounds.center, _col.size, _col.direction, 0, Vector2.up, _ctrl.pram.GrounderDistance, ~_ctrl.pram.PlayerLayer);

        // Hit a Ceiling
        if (ceilingHit && !ceilingHit.collider.isTrigger) 
        {
            CheckColliderEven.CeilingHit?.Invoke();

            //Log("ceiling hit");
        }

        // Landed on the Ground
        if (!_grounded && groundHit && !groundHit.collider.isTrigger)
        {
            _grounded = true;
            CheckColliderEven.GroundHit?.Invoke();

            //Log("ground hit");
        }
        // Left the Ground
        else if (_grounded && !groundHit)
        {
            _grounded = false;
            CheckColliderEven.GroundOut?.Invoke();

            //Log("ground out");
        }
    }

    protected virtual void CheckWall()
    {
        Vector2 direction = Vector2.right * _ctrl.transform.localScale.x;

        RaycastHit2D wallHit = Physics2D.CapsuleCast(_col.bounds.center, _col.size, _col.direction, 0, direction.normalized, _ctrl.pram.GrounderDistance, ~_ctrl.pram.PlayerLayer);

        if (!_walled && wallHit && !wallHit.collider.isTrigger)
        {           
            _walled = true;
            CheckColliderEven.WallHit?.Invoke();

            //Log("walled hit");
        }
        else if (_walled && !wallHit)
        {
            _walled = false;
            CheckColliderEven.WallOut?.Invoke();

            //Log("walled out");
        }
    }
}
public static class CheckColliderEven
{
    public static Action GroundHit;
    public static Action GroundOut;
    public static Action CeilingHit;

    public static Action WallHit;
    public static Action WallOut;
}
