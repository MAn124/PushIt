using UnityEngine;

public class ObstacleManagerCtrl : BaseMonoBehaviour
{
    [SerializeField] protected ObstaclePrefabs obstaclePrefabs;
    [SerializeField] protected ObstacleSpawner obstacleSpawner;
    public ObstaclePrefabs ObstaclePrefabs => obstaclePrefabs;
    public ObstacleSpawner ObstacleSpawner => obstacleSpawner;
  
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPrefabs();
        this.LoadSpawner();
      
    }
    protected virtual void LoadPrefabs()
    {
        if (this.obstaclePrefabs != null) return;
        this.obstaclePrefabs = GetComponentInChildren<ObstaclePrefabs>();
    }
    protected virtual void LoadSpawner()
    {
        if (this.obstacleSpawner != null) return;
        this.obstacleSpawner = GetComponentInChildren<ObstacleSpawner>();
    }
 
}
