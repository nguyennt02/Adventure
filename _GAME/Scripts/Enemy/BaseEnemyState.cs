public abstract class BaseEnemyState
{
    public bool isComplete = false;

    public virtual void Enter() { }
    public virtual void Exit() { }
    public virtual void Update() { }
}
