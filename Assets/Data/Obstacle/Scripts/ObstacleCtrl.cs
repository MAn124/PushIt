using UnityEngine;

public abstract class ObstacleCtrl : PoolObj
{
    [SerializeField] protected Transform model;
    
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }
 
}
