public abstract class EnemyState : BaseEnemyState
{
    protected Enemy _enemy;
    public EnemyState(Enemy enemy)
    {
        _enemy = enemy;
    }
}
