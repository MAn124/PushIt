using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : ObstacleManagerAbstract
{
    [SerializeField] protected List<ObstacleSpawnData> spawnData;
   

    protected void Start()
    {
        this.Spawning();
    }
  
    protected virtual void Spawning()
    {
      
    }
}
