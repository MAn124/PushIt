using UnityEngine;

public class BarrelExplode : ObstacleManagerAbstract 

{
    [SerializeField] protected float exForce = 700f;
    [SerializeField] protected float exRadius = 5f;
    [SerializeField] protected bool isExplode = false;

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Rock"))
        {
            this.Explode();
        }
    }
    protected virtual void Explode()
    {

    }
}
