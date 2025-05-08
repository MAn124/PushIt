using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawning : ObstacleManagerAbstract
{
    [SerializeField] protected int SpawnNumber = 10;
    protected List<ObstacleCtrl> obstacleSpawn = new();

    protected void Start()
    {
        this.Spawning();
    }
    protected virtual void Spawning()
    {
        Debug.Log("Spawning");
    }
}
