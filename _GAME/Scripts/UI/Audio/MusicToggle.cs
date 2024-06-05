public class MusicToggle : BaseToggle
{
    protected override void onValueChanged(bool isOn)
    {
        AudioManager.instance.ToggleMusic(isOn);
    }
}
