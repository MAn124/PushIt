using UnityEngine;

public class SliderVolumeMusic : SliderAbstract
{
    protected override void OnSliderValueChanged(float value)
    {
       SoundManagerCtrl.Instance.VolumeMusicUpdate(value);
    }
}
