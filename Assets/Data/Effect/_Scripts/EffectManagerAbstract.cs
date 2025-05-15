using UnityEngine;

public abstract class EffectManagerAbstract : BaseMonoBehaviour
{
    [SerializeField] protected EffectManagerCtrl effectManagerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObstacleManagerCtrl();
    }
    protected virtual void LoadObstacleManagerCtrl()
    {
        if (this.effectManagerCtrl != null) return;
        this.effectManagerCtrl = GetComponentInParent<EffectManagerCtrl>();
    }
}
