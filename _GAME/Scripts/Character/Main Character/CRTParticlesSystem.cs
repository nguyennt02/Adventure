using UnityEngine;
public class CRTParticlesSystem : NewMonoBehaviour
{
    [SerializeField] protected ParticleSystem _jumpParticle;
    [SerializeField] protected ParticleSystem _moveParticle;
    [SerializeField] protected ParticleSystem _landParticle;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadJumpParticle();
        LoadLandParticle();
        LoadMoveParticle();
    }

    protected virtual void LoadJumpParticle()
    {
        if (_jumpParticle) return;
        LogWarning("LoadJumpParticle");
        _jumpParticle = transform.Find("Jump Particles").GetComponent<ParticleSystem>();
    }
    protected virtual void LoadMoveParticle()
    {
        if (_moveParticle) return;
        LogWarning("LoadMoveParticle");
        _moveParticle = transform.Find("Move Particles").GetComponent<ParticleSystem>();
    }
    protected virtual void LoadLandParticle()
    {
        if (_landParticle) return;
        LogWarning("LoadLandParticle");
        _landParticle = transform.Find("Land Particles").GetComponent<ParticleSystem>();
    }
    protected virtual void OnEnable()
    {
        MoveParticlePLay();
    }
    protected virtual void OnDisable()
    {
        MoveParticleStop();
    }

    protected virtual void Update()
    {
        HandleIdleSpeed();
    }

    public virtual void JumpParticlePlay()
    {
        _jumpParticle.Play();
    }
    public virtual void MoveParticlePLay()
    {
        _moveParticle.Play();
    }
    public virtual void MoveParticleStop()
    {
        _moveParticle.Stop();
    }
    public virtual void LandParticlePlay(float impact)
    {
        _landParticle.transform.localScale = Vector3.one * Mathf.InverseLerp(0, 40, impact);
        _landParticle.Play();
    }
    public virtual void HandleIdleSpeed()
    {
        var inputStrength = Mathf.Abs(CharacterInput.Input.Move.x);
        _moveParticle.transform.localScale = Vector3.MoveTowards(_moveParticle.transform.localScale, Vector3.one * inputStrength, 2 * Time.deltaTime);
    }
}
