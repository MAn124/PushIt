using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class PlayerCtrl : BaseMonoBehaviour
{
    [SerializeField] protected Transform model;
    [SerializeField] protected PlayerMovement playerMovement;
    [SerializeField] protected Animator animator;
    [SerializeField] protected Rigidbody rb;
    [SerializeField] protected CapsuleCollider Capcollider;


    public bool isPush  { get; set; }
    public Animator Animator => animator;
    public Rigidbody Rigidbody => rb;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadModel();
        this.LoadMovement();
        this.LoadAnimator();
        this.LoadRigi();
        this.LoadCollider();
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        this.model.localPosition = new Vector3(0f, -0.65f, 0f);
    }
    protected virtual void LoadMovement()
    {
        if (this.playerMovement != null) return;
        this.playerMovement = GetComponentInChildren<PlayerMovement>();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
    }
    protected virtual void LoadRigi()
    {
        if (this.rb != null) return;
        this.rb = GetComponent<Rigidbody>();
    }
    protected virtual void LoadCollider()
    {
        if (this.Capcollider != null) return;
        this.Capcollider = GetComponentInChildren<CapsuleCollider>();
    }
}
