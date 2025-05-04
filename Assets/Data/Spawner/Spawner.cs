using UnityEngine;

public abstract class Spawner : BaseMonoBehaviour
{
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObj = Instantiate(prefab);
        return newObj;  
    }  
}
