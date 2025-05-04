using UnityEngine;

public abstract class ObstacleManagerAbstract : BaseMonoBehaviour
{
    [SerializeField] protected ObstacleManagerCtrl obstacleManagerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadObstacleManagerCtrl();
    }
    protected virtual void LoadObstacleManagerCtrl()
    {
        if (this.obstacleManagerCtrl != null) return;
        this.obstacleManagerCtrl = GetComponentInParent<ObstacleManagerCtrl>();
    }
}
