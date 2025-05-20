using UnityEngine;

public class PlayerPush : BaseMonoBehaviour
{
    [SerializeField] protected float pushForce = 500f;
    [SerializeField] protected float pushDistance = 2f;
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected void Update()
    {
        this.PushObj();
    }
    protected virtual void PushObj()
    {
        Vector3 center = transform.position + Vector3.up * 0.5f;
        float radius = 0.6f;

        Collider[] hits = Physics.OverlapSphere(center + transform.forward * 0.7f, radius);

        Collider nearestRock = null;
        float minDistance = Mathf.Infinity;

        foreach (var hit in hits)
        {
            if (hit.CompareTag("Rock"))
            {
                float dist = Vector3.Distance(transform.position, hit.transform.position);
                if (dist < minDistance)
                {
                    minDistance = dist;
                    nearestRock = hit;
                }
            }
        }

        if (Input.GetKey(KeyCode.E) && nearestRock != null)
        {
            this.playerCtrl.isPush = true;
            this.playerCtrl.Animator.SetBool("isPush", this.playerCtrl.isPush);
            this.Pushing(nearestRock);
        } else
        {
            this.playerCtrl.isPush = false;
            this.playerCtrl.Animator.SetBool("isPush", this.playerCtrl.isPush);
        }
    }
   
    protected virtual void Pushing(Collider rock)
    {
            Rigidbody rb = rock.GetComponent<Collider>()?.GetComponent<Rigidbody>();
        if (rb != null) {

            Vector3 pushDir = Vector3.ProjectOnPlane(transform.forward, Vector3.up).normalized;

            float velocity = rb.linearVelocity.magnitude;
            float multiplier = velocity > 0.1f ? 2f : 1f;

            rb.AddForce(pushDir * pushForce * multiplier, ForceMode.Force);
        }                   
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
}
