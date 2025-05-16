using UnityEngine;

public abstract class SoundManagerAbstract : BaseMonoBehaviour
{
    [SerializeField] protected SoundManagerCtrl soundManagerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSoundManagerCtrl();
    }
    protected virtual void LoadSoundManagerCtrl()
    {
        if (this.soundManagerCtrl != null) return;
        this.soundManagerCtrl = GetComponentInParent<SoundManagerCtrl>();
    }
}
