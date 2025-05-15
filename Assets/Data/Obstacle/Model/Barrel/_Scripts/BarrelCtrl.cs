using UnityEngine;

public class BarrelCtrl : ObstacleCtrl
{
    [SerializeField] protected BarrelExplosion barrelExplosion;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBarrelEx();
    }
    protected virtual void LoadBarrelEx()
    {
        if (this.barrelExplosion != null) return;
        this.barrelExplosion = GetComponentInChildren<BarrelExplosion>();
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {           
            barrelExplosion.Explosion(this.transform);
        }
    }
}
