public class SFXToggle : BaseToggle
{
    protected override void onValueChanged(bool isOn)
    {
        AudioManager.instance.ToggleSFX(isOn);
    }
}
