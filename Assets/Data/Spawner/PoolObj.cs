using UnityEngine;

public class PoolObj : BaseMonoBehaviour
{
    [SerializeField] protected DespawnBase despawn;
    public DespawnBase Despawn => despawn;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<DespawnBase>();
    }
}
