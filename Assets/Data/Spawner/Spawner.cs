using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : BaseMonoBehaviour
{
    [SerializeField] protected List<T> inPoolObj;
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObj = Instantiate(prefab);
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
}
