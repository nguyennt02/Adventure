public abstract class BaseEnemy : NewMonoBehaviour
{
    public EnemyAnimManager anim;

    protected BaseEnemyState _state;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        LoadEnemyAnimManager();
    }

    protected virtual void LoadEnemyAnimManager()
    {
        if (anim) return;
        LogWarning("LoadEnemyAnimManager");
        anim = GetComponentInParent<EnemyAnimManager>();
    }

    protected virtual void Update()
    {
        _state.Update();
    }
    protected virtual void StartState(BaseEnemyState state)
    {
        if (_state == null)
        {
            _state = state;
            _state.Enter();
        }
        else
        {
            ChangeState(state);
        }
    }
    public virtual void ChangeState(BaseEnemyState state)
    {
        if (state != _state || _state.isComplete)
        {
            _state.Exit();
            _state = state;
            _state.Enter();
        }
    }
}
