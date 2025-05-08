using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePrefabs : ObstacleManagerAbstract
{
    [SerializeField] protected List<ObstacleCtrl> obstacles = new();
    protected void Start()
    {
        this.HidePrefabs();

    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
    }
    protected virtual void LoadPrefabs()
    {
        if (this.obstacles.Count > 0) return;
        foreach(Transform child in transform)
        {
            ObstacleCtrl obstacleCtrl = child.GetComponent<ObstacleCtrl>();
            if(obstacleCtrl) this.obstacles.Add(obstacleCtrl);
        }
        
    }
    protected virtual void HidePrefabs()
    {
        foreach(ObstacleCtrl obstacleCtrl in this.obstacles)
        {
         
            obstacleCtrl.gameObject.SetActive(false);
        }
    }
}
