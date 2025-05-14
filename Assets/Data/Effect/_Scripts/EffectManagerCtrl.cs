using UnityEngine;

public class EffectManagerCtrl :EffectManagerAbstract
{
    [SerializeField] protected EffectPrefabs effectPrefabs;
    [SerializeField] protected EffectSpawner effectSpawner;
    public EffectPrefabs EffectPrefabs => effectPrefabs;
    public EffectSpawner EffectSpawner => effectSpawner;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadSpawner();

    }
    protected virtual void LoadPrefabs()
    {
        if (this.effectPrefabs != null) return;
        this.effectPrefabs = GetComponentInChildren<EffectPrefabs>();
    }
    protected virtual void LoadSpawner()
    {
        if (this.effectSpawner != null) return;
        this.effectSpawner = GetComponentInChildren<EffectSpawner>();
    }

}
