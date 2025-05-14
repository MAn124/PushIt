using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : ObstacleManagerAbstract
{
    [Header("Barrel")]
    [SerializeField] private BarrelCtrl barrelCtrl;
    [SerializeField] private List<Transform> barrelSpawnPoints;

    [Header("WoodStick")]
    [SerializeField] private WoodStickCtrl woodStickCtrl;
    [SerializeField] private List<Transform> woodStickSpawnPoints;

    [Header("SpikeTrap")]
    [SerializeField] private SpikeTrapCtrl spikeTrapCtrl;
    [SerializeField] private List<Transform> spikeTrapSpawnPoints;
    protected void Start()
    {
        this.Spawning();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
      
    }
   
    protected virtual void Spawning()
    {
        SpawnGroup(barrelCtrl, barrelSpawnPoints);
        SpawnGroup(woodStickCtrl, woodStickSpawnPoints);
        SpawnGroup(spikeTrapCtrl, spikeTrapSpawnPoints);
    }
    protected virtual void SpawnGroup(ObstacleCtrl prefab,List<Transform> points)
    {
        foreach (Transform point in points)
        {
            this.obstacleManagerCtrl.ObstacleSpawner.Spawn(prefab, point);
        }
    }
}
