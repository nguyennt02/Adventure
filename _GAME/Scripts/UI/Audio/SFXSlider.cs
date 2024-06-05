using UnityEngine;

public class SFXSlider : BaseSlider
{
    protected override void onValueChanged(float value)
    {
        AudioManager.instance.SFXVolume(value);
    }

    protected override void SetValueSlider()
    {
        _slider.value = PlayerPrefs.GetFloat("SFXVolume", 0.5f);
    }
}
