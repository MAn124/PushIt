using UnityEngine;

public class ObstaclePrefabs : ObstacleManagerAbstract
{
    [SerializeField] protected BarrelSpawner spawner;
    [SerializeField] protected BarrelCtrl barrelCtrl;

    protected void Start()
    {
        this.HidePrefabs();
        Invoke(nameof(this.SpawnBarrel), 2f);
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawner();
        this.LoadBarrel();
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = FindAnyObjectByType<BarrelSpawner>();
    }
    protected virtual void LoadBarrel()
    {
        if (this.barrelCtrl != null) return;
        this.barrelCtrl = GetComponentInChildren<BarrelCtrl>();
    }
    protected virtual void SpawnBarrel()
    {
        Invoke(nameof(this.SpawnBarrel), 2f);

        this.spawner.Spawn(this.barrelCtrl);
    }
    protected virtual void HidePrefabs()
    {
        this.barrelCtrl.gameObject.SetActive(false);
    }
}
