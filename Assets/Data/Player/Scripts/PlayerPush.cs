using UnityEngine;

public class PlayerPush : BaseMonoBehaviour
{
    [SerializeField] protected float pushForce = 10f;
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
        bool isRockInFront = Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, pushDistance)
                        && hit.collider.CompareTag("Rock");
        if (Input.GetKey(KeyCode.E) && isRockInFront)
        {
            this.playerCtrl.isPush = true;
            this.playerCtrl.Animator.SetBool("isPush", this.playerCtrl.isPush);
            this.Pushing();
        } else
        {
            this.playerCtrl.isPush = false;
            this.playerCtrl.Animator.SetBool("isPush", this.playerCtrl.isPush);
        }
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
    protected virtual void Pushing()
    {
        Debug.Log("Pushing");
        Ray ray = new(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, pushDistance))
        {
            Debug.Log("Ray hit: " + hit.collider.name);
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();
            if (rb != null) rb.AddForce(transform.forward * pushForce, ForceMode.Force);               
        }
    }
}
