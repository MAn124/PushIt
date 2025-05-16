using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public abstract class SoundCtrl : PoolObj
{
    [SerializeField] protected AudioSource audioSource;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadAudio();
    }
    protected virtual void LoadAudio()
    {
        if (this.audioSource != null) return;
        this.audioSource = GetComponent<AudioSource>();
    }
}
