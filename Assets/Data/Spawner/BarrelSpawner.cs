using UnityEngine;

    public class BarrelSpawner : Spawner<BarrelCtrl>
    {
      public virtual BarrelCtrl Spawn(BarrelCtrl prefabs)
        {
            BarrelCtrl newObj = Instantiate(prefabs);
            newObj.Despawn.SetSpawner(this);  
            return newObj;
        }
        public virtual BarrelCtrl Spawn(BarrelCtrl prefabs, Vector3 position)
        {
            BarrelCtrl newObj = this.Spawn  (prefabs);
            newObj.transform.position = position;
            return newObj;
        }
    }
