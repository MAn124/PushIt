using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ObstacleSpawnData", menuName = "Spawn/Obstacle Spawn Data")]
public class ObstacleSpawnData : ScriptableObject
{
    public GameObject prefab;                  
    public List<Vector3> spawnPositions;
}
