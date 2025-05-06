using UnityEngine;

public class BarrelCtrl : BaseMonoBehaviour
{
    [SerializeField] protected BarrelDespawn despawn;
    public BarrelDespawn Despawn => despawn;

   
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadDespawn();
    }
    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<BarrelDespawn>();
    }
   
}
