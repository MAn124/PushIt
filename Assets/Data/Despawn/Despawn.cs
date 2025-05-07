using UnityEngine;

public abstract class Despawn<T> : DespawnBase where T :PoolObj
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
        this.LoadSpawner();
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
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner =GameObject.FindAnyObjectByType<Spawner<T>>();
    }
}
