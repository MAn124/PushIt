using UnityEngine;

    public class BarrelSpawner : Spawner<Barrel>
    {
      public virtual Barrel Spawn(Barrel prefabs)
        {
            Barrel newObj = Instantiate(prefabs);
            newObj.Despawn.SetSpawner(this);  
            return newObj;
        }
        public virtual Barrel Spawn(Barrel prefabs, Vector3 position)
        {
            Barrel newObj = this.Spawn  (prefabs);
            newObj.transform.position = position;
            return newObj;
        }
    }
