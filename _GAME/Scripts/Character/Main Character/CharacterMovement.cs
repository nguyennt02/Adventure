using System.Collections;
using UnityEngine;
using static CharacterInput;

public class CharacterMovement : CCEventExecution
{
    [SerializeField] protected CharacterCtrl _ctrl;
    [SerializeField] protected Rigidbody2D _rb;
    protected Vector2 _frameVelocity;
    protected FrameInput _frameInput = new FrameInput();
    protected FrameInput _fixedUpdateInput = new FrameInput();

    protected float _time;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadCharacterCtrl();
        LoadRigidbody2D();
    }

    protected virtual void LoadRigidbody2D()
    {
        if (_rb) return;
        LogWarning("LoadRigidbody2D");
        _rb = GetComponentInParent<Rigidbody2D>();
    }

    protected virtual void LoadCharacterCtrl()
    {
        if (_ctrl) return;
        LogWarning("LoadCharacterCtrl");
        _ctrl = GetComponentInParent<CharacterCtrl>();
    }

    protected virtual void Update()
    {
        _time += Time.deltaTime;
        GatherInput();
        FixedUpdateInput();
    }


    protected virtual void FixedUpdate()
    {
        HandleRun();

        HandleJump();

        GroundHiting();

        ChangeState();

        xVelocityAnim();

        ApplyMovement();

        ResetFixedUpdateInput();
    }

    #region INPUT
    protected virtual void GatherInput()
    {
        _frameInput = CharacterInput.Input;
        if (_ctrl.pram.SnapInput)
        {
            _frameInput.Move.x = Mathf.Abs(_frameInput.Move.x) < _ctrl.pram.HorizontalDeadZoneThreshold ? 0 : Mathf.Sign(_frameInput.Move.x);
            _frameInput.Move.y = Mathf.Abs(_frameInput.Move.y) < _ctrl.pram.VerticalDeadZoneThreshold ? 0 : Mathf.Sign(_frameInput.Move.y);
        }

        if (_frameInput.JumpDown)
        {
            _jumpToConsume = true;
            _timeJumpWasPressed = _time;
        }
        if (_frameInput.Dash && _dashing)
        {
            _timeDashWasPressed = _time;
        }
    }
    protected virtual void FixedUpdateInput()
    {
        if(_frameInput.Dash || _frameInput.JumpDown)
            _fixedUpdateInput = _frameInput;
    }
    protected virtual void ResetFixedUpdateInput()
    {
        _fixedUpdateInput.Dash = false;
        _fixedUpdateInput.JumpDown = false;
    }
    #endregion

    #region CHECK COLLIDER
    protected float _frameLeftGrounded = float.MinValue;
    protected override void GroundHit()
    {
        base.GroundHit();
        _coyoteUsable = true;
        _bufferedJumpUsable = true;
        _endedJumpEarly = false;

        _ctrl.cParticle.MoveParticlePLay();
        _ctrl.cParticle.LandParticlePlay(Mathf.Abs(_frameVelocity.y));
        AudioManager.instance.PlaySFX("Land");
    }
    protected override void GroundOut()
    {
        base.GroundOut();
        _frameLeftGrounded = _time;

        _ctrl.cParticle.MoveParticleStop();
    }
    protected override void WallHit()
    {
        _touchingTheWall = true;
    }
    protected override void CeilingHit()
    {
        base.CeilingHit();
        _touchingTheWall = true;
        _frameVelocity.y = Mathf.Min(0, _frameVelocity.y);
    }
    protected virtual void GroundHiting()
    {
        if (!_ctrl.cCol.grounded) return;
        _dashNumber = 0;
        if (_timeSlide > 0)
            _timeSlide -= (Time.fixedDeltaTime * _ctrl.pram.RecoveryRate);
    }
    #endregion

    #region RUN
    protected virtual void HandleRun()
    {
        if (_frameInput.Move.x == 0)
        {
            CRTIdel();
            var deceleration = _ctrl.cCol.grounded ? _ctrl.pram.GroundDeceleration : _ctrl.pram.AirDeceleration;
            _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, 0, deceleration * Time.fixedDeltaTime);
        }
        else
        {
            HandleSpriteFlip();
            _frameVelocity.x = Mathf.MoveTowards(_frameVelocity.x, _frameInput.Move.x * _ctrl.pram.MaxSpeed, _ctrl.pram.Acceleration * Time.fixedDeltaTime);
            if (_ctrl.cCol.grounded)
            {
                CRTRun();
                if (!isAudioRun) StartCoroutine(AudioRun());
            }
        }
    }
    #endregion

    #region JUMP
    protected bool _endedJumpEarly;
    protected bool _jumpToConsume;
    protected bool _bufferedJumpUsable;
    protected bool _coyoteUsable;
    protected float _timeJumpWasPressed;

    protected bool HasBufferedJump => _bufferedJumpUsable && _time < _timeJumpWasPressed + _ctrl.pram.JumpBuffer;
    protected bool CanUseCoyote => _coyoteUsable && !_ctrl.cCol.grounded && _time < _frameLeftGrounded + _ctrl.pram.CoyoteTime;

    protected virtual void HandleJump()
    {
        if (!_endedJumpEarly && !_ctrl.cCol.grounded && !_frameInput.JumpHeld && _rb.velocity.y > 0) _endedJumpEarly = true;

        if (!_jumpToConsume && !HasBufferedJump) return;

        if (_ctrl.cCol.grounded || CanUseCoyote) ExecuteJump();

        _jumpToConsume = false;
    }

    protected virtual void ExecuteJump()
    {
        _endedJumpEarly = false;
        _timeJumpWasPressed = 0;
        _bufferedJumpUsable = false;
        _coyoteUsable = false;
        _frameVelocity.y = _ctrl.pram.JumpPower;

        if (_ctrl.cCol.grounded)
        {
            AudioManager.instance.PlaySFX("Jump");
            _ctrl.cParticle.JumpParticlePlay();
        }
    }
    #endregion

    #region STATE
    protected virtual void ChangeState()
    {
        if (!_ctrl.cCol.grounded && _ctrl.cCol.walled && _fixedUpdateInput.JumpDown && _frameInput.Hold)
        {
            OnFacing();
            HandleJumpWall();
            AudioManager.instance.PlaySFX("Jump");
        }
        else if (!_ctrl.cCol.grounded && _ctrl.cCol.walled && _frameInput.Hold && !_jumping)
        {
            HandleHold();
            Climbwall();
            CRTHold();
        }
        else if (!_ctrl.cCol.walled &&
                (_fixedUpdateInput.Dash || HasBufferedDash) &&
                !_dashing &&
                _dashNumber < _ctrl.pram.NumberOfAerialDash &&
                _ctrl.pram.CanDash)
        {
            AudioManager.instance.PlaySFX("Dash");
            HandleDash();
        }
        else if (_ctrl.cCol.grounded && _frameVelocity.y <= 0f)
        {
            GroundingForce();
        }
        else
        {
            CRTOverhead();
            Gravity();
        }
    }

    #region JUMP WALL
    protected bool _touchingTheWall = false;
    protected virtual void HandleJumpWall()
    {
        float xJumpWall = Mathf.Sign(_ctrl.transform.localScale.x);
        Vector3 from = new Vector3(xJumpWall, _frameInput.Move.y, 0) * _ctrl.pram.JumpWallPower;
        StartCoroutine(JumpWall(_ctrl.pram.TimeJumpWall, from));
    }

    protected bool _jumping = false;
    protected virtual IEnumerator JumpWall(float duration, Vector3 from, float elapsed = 0f)
    {
        _jumping = true;
        _touchingTheWall = false;
        Vector3 to = Vector3.zero;
        while (elapsed < duration && !_touchingTheWall && !_dashing)
        {
            _frameVelocity = Vector3.Lerp(from, to, (elapsed) / duration);
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        _jumping = false;
        _frameVelocity = to;
    }
    #endregion

    #region HOLD
    protected float _timeSlide = 0;
    protected virtual void HandleHold()
    {
        float timeSlide = _ctrl.pram.TimeSlide;
        if (_timeSlide < timeSlide/4)
        {
            Vector3 from = new Vector3(_frameVelocity.x, 0, 0);
            Vector3 to = new Vector3(_frameVelocity.x, -_ctrl.pram.MinSpeedWallSlide, 0);

            WallSlide(from, to, timeSlide / 4);
        }
        else if (_timeSlide < timeSlide)
        {
            Vector3 from = new Vector3(_frameVelocity.x, -_ctrl.pram.MinSpeedWallSlide, 0);
            Vector3 to = new Vector3(_frameVelocity.x, -_ctrl.pram.MaxSpeedWallSlide, 0);

            WallSlide(from, to, timeSlide);
        }
        else
            _frameVelocity = new Vector3(_frameVelocity.x, -_ctrl.pram.MaxSpeedWallSlide, 0);
        _timeSlide += Time.fixedDeltaTime;
    }
    protected virtual void WallSlide(Vector3 from, Vector3 to, float timeSlide)
    {
        _frameVelocity = Vector3.Lerp(from, to, _timeSlide / timeSlide);
    }

    protected virtual void Climbwall()
    {
        if (_frameInput.Move.y != 0)
            _frameVelocity.y += (_frameInput.Move.y * _ctrl.pram.SpeedClimbwall);
    }
    #endregion

    #region DASH
    protected bool _dashing = false;
    protected int _dashNumber = 0;
    protected float _timeDashWasPressed = 0;
    protected bool HasBufferedDash => _timeDashWasPressed != 0 && _time < _timeDashWasPressed + _ctrl.pram.TimeDash;

    protected virtual void HandleDash()
    {
        _dashNumber++;
        var direction = Direction() * _ctrl.pram.DashPower;
        StartCoroutine(Dash(_ctrl.pram.TimeDash, direction));
    }
    protected virtual Vector3 Direction()
    {
        if (_frameInput.Move != Vector2.zero)
        {
            return _frameInput.Move.normalized;
        }
        else
        {
            Vector2 direction = Vector2.right * _ctrl.transform.localScale.x;
            return direction.normalized;
        }
    }
    protected virtual IEnumerator Dash(float duration, Vector3 from, float elapsed = 0f)
    {
        _dashing = true;
        _ctrl.cTranlRen.Emitting(true);
        Vector3 to = Vector3.zero;
        _touchingTheWall = false;
        while (elapsed < duration && !_touchingTheWall)
        {
            _frameVelocity = Vector3.Lerp(from, to, (elapsed) / duration);
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForSeconds(Time.fixedDeltaTime);
        }
        _frameVelocity = to;
        _dashing = false;
        _ctrl.cTranlRen.Emitting(false);
    }
    #endregion

    #region GROUNDING FORCE
    protected virtual void GroundingForce()
    {
        _frameVelocity.y = _ctrl.pram.GroundingForce;
    }
    #endregion

    #region GRAVITY
    protected virtual void Gravity()
    {
        var inAirGravity = _ctrl.pram.FallAcceleration;
        if (_endedJumpEarly && _frameVelocity.y > 0) inAirGravity *= _ctrl.pram.JumpEndEarlyGravityModifier;
        _frameVelocity.y = Mathf.MoveTowards(_frameVelocity.y, -_ctrl.pram.MaxFallSpeed, inAirGravity * Time.fixedDeltaTime);
    }
    #endregion

    #endregion

    #region PLIP
    protected bool isFacingRight = true;
    protected virtual void HandleSpriteFlip()
    {
        if (isFacingRight && _frameInput.Move.x < 0 ||
            !isFacingRight && _frameInput.Move.x > 0)
            OnFacing();
    }
    protected virtual void OnFacing()
    {
        isFacingRight = !isFacingRight;
        _ctrl.transform.localScale = new Vector3(
            -_ctrl.transform.localScale.x,
            _ctrl.transform.localScale.y,
            _ctrl.transform.localScale.z);
    }
    #endregion

    #region ANIM
    protected virtual void CRTIdel()
    {
        if (_ctrl.cCol.grounded)
            _ctrl.anim.SetCRTState(CRTSTATE.IDEL);
    }
    protected virtual void CRTRun()
    {
        _ctrl.anim.SetCRTState(CRTSTATE.RUN);
    }
    protected virtual void CRTHold()
    {
        _ctrl.anim.SetCRTState(CRTSTATE.HOLD);
    }
    protected virtual void CRTOverhead()
    {
        if (!_ctrl.cCol.grounded)
            _ctrl.anim.SetCRTState(CRTSTATE.OVERHEAD);
    }
    protected virtual void xVelocityAnim()
    {
        _ctrl.anim.SetyVelocity(_frameVelocity.y);
    }
    #endregion
    protected bool isAudioRun = false;
    protected virtual IEnumerator AudioRun()
    {
        AudioManager.instance.PlaySFX("Run");
        isAudioRun = true;
        yield return new WaitForSeconds(0.5f);
        isAudioRun = false;
    }
    #region AUDIO

    #endregion
    protected virtual void ApplyMovement() => _rb.velocity = _frameVelocity;
    public virtual void SetFrameVelocity(Vector2 frameVelocity) => _frameVelocity = frameVelocity;
    protected override void OnDisable()
    {
        base.OnDisable();
        _dashing = false;
        _jumping = false;
        _ctrl.cTranlRen.Emitting(false);
        SetFrameVelocity(Vector2.zero);
        _timeDashWasPressed = 0;
    }
}
