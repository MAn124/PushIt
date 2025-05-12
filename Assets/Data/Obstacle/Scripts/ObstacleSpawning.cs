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
    [SerializeField] private List<Transform> rockSpawnPoints;

    [Header("SpikeTrap")]
    [SerializeField] private SpikeTrapCtrl spikeTrapCtrl;
    [SerializeField] private List<Transform> boxSpawnPoints;
    protected void Start()
    {
        this.Spawning();
    }
  
    protected virtual void Spawning()
    {
        SpawnGroup(barrelCtrl, barrelSpawnPoints);
        SpawnGroup(woodStickCtrl, rockSpawnPoints);
        SpawnGroup(spikeTrapCtrl, boxSpawnPoints);
    }
    protected virtual void SpawnGroup(ObstacleCtrl prefab,List<Transform> points)
    {
        foreach (Transform point in points)
        {
            this.obstacleManagerCtrl.ObstacleSpawner.Spawn(prefab, point);
        }
    }
}
