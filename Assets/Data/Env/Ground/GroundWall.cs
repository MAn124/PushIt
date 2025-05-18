using UnityEngine;

public class GroundWall : BaseMonoBehaviour
{
    [SerializeField] protected GameObject wallPrefab;
    [SerializeField] protected float radius = 25f;
    [SerializeField] protected float gapAngle = 30f;

    protected override void Start()
    {
        this.SpawnWall();

    }
    protected virtual void SpawnWall()
    {
        if (wallPrefab == null) return;

        float wallWidth = wallPrefab.GetComponent<Renderer>().bounds.size.x;
        float circumference = 2 * Mathf.PI * radius;
        float arcLengthAvailable = circumference * (1f - gapAngle / 360f);
        int segmentCount = Mathf.FloorToInt(arcLengthAvailable / wallWidth);

        float angleStep = (360f - gapAngle) / segmentCount;
        float startAngle = gapAngle / 2f;

        for (int i = 0; i < segmentCount; i++)
        {
            float angleDeg = startAngle + i * angleStep;
            float angleRad = angleDeg * Mathf.Deg2Rad;

            Vector3 localPos = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad)) * radius;
            GameObject wall = Instantiate(wallPrefab, transform);
            wall.transform.localPosition = localPos;
            wall.transform.localRotation = Quaternion.LookRotation(-localPos);
        }
    }
}
