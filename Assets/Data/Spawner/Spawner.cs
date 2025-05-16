using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public abstract class Spawner<T> : BaseMonoBehaviour where T : PoolObj
{
    [SerializeField] protected List<T> inPoolObj;
    [SerializeField] protected PoolHolder poolHolder;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPool();
    }
    protected virtual void LoadPool()
    {
        if (this.poolHolder != null) return;
        this.poolHolder= transform.GetComponentInChildren<PoolHolder>();
    }
    public virtual T Spawn(T prefabs)
    {
        T newObj = this.GetObjFromPool(prefabs);
        if (newObj == null) {
        
         newObj = Instantiate(prefabs);
        }
        if (this.poolHolder != null) { 
            newObj.transform.parent = this.poolHolder.transform;
        }
        return newObj;
    }
    public virtual T Spawn(T prefabs,Transform point)
    {
        T newObj = this.Spawn(prefabs);
        RaycastHit hit;
        if (Physics.Raycast(point.position + Vector3.up, Vector3.down, out hit, 10f))
        {
      
            newObj.transform.position = hit.point;

           
            newObj.transform.up = hit.normal;
        }
        else
        {
            
            newObj.transform.position = point.position;
        }

        newObj.gameObject.SetActive(true);
        return newObj;
    }
    public virtual void Despawn(Transform obj)
    {
       Destroy(obj.gameObject);
    }
    public virtual void Despawn(T obj)
    {
        if(obj is MonoBehaviour mono)
        {
          mono.gameObject.SetActive(false);
          this.AddObjToPool(obj);
        }
    }
    protected virtual void AddObjToPool(T obj) {
        this.inPoolObj.Add(obj);
    }
    protected virtual void RemoveObjFromPool(T obj)
    {
        this.inPoolObj.Remove(obj);
    }
    protected virtual T GetObjFromPool(T prefabs)
    {
        foreach (T inPoolObj in inPoolObj) { 
        if(prefabs.name == inPoolObj.name) {
                this.RemoveObjFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }
  
}
