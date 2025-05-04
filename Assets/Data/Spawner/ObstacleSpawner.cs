using UnityEngine;

public class ObstacleSpawner : Spawner
{
   public virtual Transform Spawn(Transform prefab, Vector3 position)
    {
        Transform newObj = Instantiate(prefab);
        newObj.transform.position = position;
        return newObj;
    }
}
