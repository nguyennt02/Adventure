public class MoveFlatformChangeDirection : MoveFlatforms
{
    protected override void ChangePoint()
    {
        ChangeDirection();
        ChangeIndex();
    }
    protected virtual void ChangeDirection()
    {
        if (isChangDirection)
            _direction *= -1;
    }
    protected virtual bool isChangDirection => _index == 0 || _index == _arrPoint.Length - 1;

}
