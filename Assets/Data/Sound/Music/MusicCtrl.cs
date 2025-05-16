using UnityEngine;

public class MusicCtrl : SoundCtrl
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.audioSource.loop = true;
    }
}
