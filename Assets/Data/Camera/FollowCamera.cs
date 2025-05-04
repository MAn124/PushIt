using System.Security.Cryptography;
using UnityEngine;

public class FollowCamera : BaseMonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected Vector3 offset = new Vector3(0f, 1.7f, -4f);
    [SerializeField] protected float xSpeed = 5f;
    [SerializeField] protected float ySpeed = 4f;
    [SerializeField] protected float xMinRotation = -360f;
    [SerializeField] protected float xMaxRotation = 360f;
    [SerializeField] protected float yMinRotation = 10f;
    [SerializeField] protected float yMaxRotation = 80f;

    protected Quaternion rotation;
    protected float x;
    protected float y;
    protected override void Awake()
    {
        this.SetAngle();
    }
    protected void LateUpdate()
    {
        this.CamMove();
        this.CamPosition();
    }
    protected override void LoadComponent()
    {
        base.LoadComponent();
  
    }
  
    protected virtual void SetAngle()
    {
        Vector3 angles = this.transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }
    protected virtual void CamMove()
    {
        x += Input.GetAxis("Mouse X") * xSpeed;
        y += Input.GetAxis("Mouse Y") * ySpeed;
        
        x = ClampAngle(x, xMinRotation, xMaxRotation);
        y = ClampAngle(y, yMinRotation, yMaxRotation);
    }
    protected virtual float ClampAngle(float angle, float min, float max)
    {
        if (angle < 360f) angle += 360f;
        if (angle > 360f) angle -= 360f;

        return Mathf.Clamp(angle, min, max);
    }
    protected virtual void CamPosition()
    {

        rotation = Quaternion.Euler(y, x, 0f);

        Vector3 distanceVec = offset;
        Vector3 camPosition = rotation * distanceVec + target.position;
        transform.rotation = rotation;
        transform.position = camPosition;
    }
}
