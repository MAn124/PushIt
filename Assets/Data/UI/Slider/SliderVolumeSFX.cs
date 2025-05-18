using UnityEngine;

public class SliderVolumeSFX : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
        SoundManagerCtrl.Instance.VolumeSFXUpdate(value);
    }
}
