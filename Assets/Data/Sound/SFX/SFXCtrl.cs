using UnityEngine;

public class SFXCtrl : SoundCtrl
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.audioSource.loop = false;
    }
}
