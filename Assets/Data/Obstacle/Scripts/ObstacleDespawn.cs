using UnityEngine;

public class ObstacleDespawn : Despawn<ObstacleCtrl>
{
    [SerializeField] protected bool isDespawn = false;

    protected new virtual void FixedUpdate()
    {
        this.CheckDespawn();
    }
    protected virtual void CheckDespawn()
    {
        if (!isDespawn) return;
        this.spawner.Despawn(transform.parent);
    }
}
