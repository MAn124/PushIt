using UnityEngine;

public class SpikeTrapRotate : MonoBehaviour
{
    [SerializeField] private Vector3 rotationSpeed = new(0f, 90f, 0f); 

    void Update()
    {
        transform.parent.Rotate(rotationSpeed * Time.deltaTime);
    }
}
