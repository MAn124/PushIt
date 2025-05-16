using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : BaseMonoBehaviour 

{
    [SerializeField] protected BarrelCtrl barrelCtrl;
    [SerializeField] protected ObstacleManagerCtrl obstacleManagerCtrl;
    [SerializeField] protected EffectManagerCtrl effectManagerCtrl;
    [SerializeField] protected EffectCtrl ExEffect;
    [SerializeField] protected SoundManagerCtrl soundManagerCtrl;
    [SerializeField] protected SoundName exSound = SoundName.ExplosionSound;
    [SerializeField] protected float exForce = 10f;
    [SerializeField] protected float exRadius = 10f;
    [SerializeField] protected float respawnTime = 5f;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadCtrl();
        this.LoadEffect();
        this.LoadSound();
        this.LoadObstacleManager();
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
        this.SpawnSound();
        Vector3 explosionPos = this.transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, this.exRadius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null && rb != this.GetComponent<Rigidbody>())
            {
                rb.AddExplosionForce(this.exForce, explosionPos, this.exRadius, 0.2f, ForceMode.Force);
            }
        }
        CoroutineRunner.Instance.StartCoroutine(Respawn(barrelCtrl,5f));     
    }  
    protected virtual IEnumerator Respawn(ObstacleCtrl prefabs, float delay)
    {
        yield return new WaitForSeconds(delay);
        this.obstacleManagerCtrl.ObstacleSpawner.Spawn(prefabs, this.transform);
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
    protected virtual void LoadSound()
    {
        if (this.soundManagerCtrl != null) return;
        this.soundManagerCtrl = FindAnyObjectByType<SoundManagerCtrl>();
    }
    protected virtual void SpawnSound()
    {

        SFXCtrl spawnSfx = (SFXCtrl)this.soundManagerCtrl.CreatSFX(exSound);
        spawnSfx.gameObject.SetActive(true);
    }
}
