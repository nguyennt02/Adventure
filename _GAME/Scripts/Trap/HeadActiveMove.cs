public class HeadActiveMove : FlatformsActiveMove
{
    protected override void LoadFlatformsCtrl()
    {
        if (_ctrl) return;
        LogWarning("LoadFlatformsCtrl");
        _ctrl = transform.parent.GetComponentInChildren<FlatformsCtrl>();
    }
}
