using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : BaseMonoBehaviour 

{
    [SerializeField] protected BarrelCtrl barrelCtrl;
    [SerializeField] protected ObstacleManagerCtrl obstacleManagerCtrl;
    [SerializeField] protected EffectManagerCtrl effectManagerCtrl;
    [SerializeField] protected float exForce = 700f;
    [SerializeField] protected float exRadius = 5f;
    [SerializeField] protected EffectCtrl ExEffect;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
        this.LoadObstacleManager();
        this.LoadEffect();
    }
    protected virtual void LoadCtrl()
    {
        if(this.barrelCtrl != null) return;
        this.barrelCtrl = GetComponentInParent<BarrelCtrl>();
    }
    public virtual void Explosion(Transform prefab)
    {
        this.obstacleManagerCtrl.ObstacleSpawner.Despawn(this.GetComponentInParent<ObstacleCtrl>());
        Debug.Log("Hitting");
       
        this.effectManagerCtrl.EffectSpawner.Spawn(ExEffect, this.transform);
        //Invoke(nameof(Respawn), 15f);
    }
   
  protected virtual void LoadObstacleManager()
    {
        if(this.obstacleManagerCtrl != null) return;
        this.obstacleManagerCtrl = FindAnyObjectByType<ObstacleManagerCtrl>();
    }
    protected virtual void LoadEffect()
    {
        if (this.effectManagerCtrl != null) return;
        this.effectManagerCtrl = FindAnyObjectByType<EffectManagerCtrl>();
    }
}
