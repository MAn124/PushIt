using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplosion : ObstacleManagerAbstract 

{
    [SerializeField] protected float exForce = 700f;
    [SerializeField] protected float exRadius = 5f;
    [SerializeField] protected bool isExplosion = false;
    protected List<Transform> isExploded = new();
    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
         Invoke(nameof(this.Explosion), 2f);
        }
    }
    protected virtual void Explosion(ObstacleCtrl prefab)
    {
        //this.obstacleManagerCtrl.ObstacleSpawner.Despawn(prefab);
        Debug.Log("Hitting");
        //Invoke(nameof(Respawn), 15f);
    }
    protected virtual void Respawn(ObstacleCtrl prefab, List<Transform> position)
    {
        foreach (Transform point in position)
        {
            this.obstacleManagerCtrl.ObstacleSpawner.Spawn(prefab, point);
        }
    }
}
