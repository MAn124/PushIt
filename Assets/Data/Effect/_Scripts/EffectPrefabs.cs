using System.Collections.Generic;
using UnityEngine;

public class EffectPrefabs : EffectManagerAbstract
{
    [SerializeField] protected List<EffectCtrl> effects = new();
    protected void Start()
    {
        this.HidePrefabs();

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.effects.Count > 0) return;
        foreach (Transform child in transform)
        {
            EffectCtrl effectCtrl = child.GetComponent<EffectCtrl>();
            if (effectCtrl) this.effects.Add(effectCtrl);
        }

    }
    protected virtual void HidePrefabs()
    {
        foreach (EffectCtrl effectCtrl in this.effects)
        {

            effectCtrl.gameObject.SetActive(false);
        }
    }
}
