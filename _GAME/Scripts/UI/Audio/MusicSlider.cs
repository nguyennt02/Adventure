using UnityEngine;

public class MusicSlider : BaseSlider
{
    protected override void onValueChanged(float value)
    {
        AudioManager.instance.MusicVolume(value);
    }

    protected override void SetValueSlider()
    {
        _slider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
    }
}
