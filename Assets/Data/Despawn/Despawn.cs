using UnityEngine;

public abstract class Despawn<T> : BaseMonoBehaviour
{
    [SerializeField] protected Spawner<T> spawner;
    [SerializeField] protected T parent;
    protected void FixedUpdate()
    {
        this.DespawnCheck();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadParent();
    }
    protected virtual void LoadParent()
    {
        if (this.parent != null) return;
        this.parent = transform.parent.GetComponentInChildren<T>();
    }
    protected virtual void DespawnCheck()
    {
        this.spawner.Despawn(this.parent);
    }
    public virtual void SetSpawner(Spawner<T> spawner)
    {
        this.spawner = spawner;
    }
}
