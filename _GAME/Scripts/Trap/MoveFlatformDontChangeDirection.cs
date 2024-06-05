public class MoveFlatformDontChangeDirection : MoveFlatforms
{
    protected override void ChangePoint()
    {
        Change();
    }

    protected virtual void Change()
    {
        if (isChangeIndex)
            _index = 0;
        else
            ChangeIndex();
    }

    protected virtual bool isChangeIndex => _index == _arrPoint.Length - 1;
}
