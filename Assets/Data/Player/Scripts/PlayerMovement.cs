using UnityEngine;


public class PlayerMovement : BaseMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected bool isMoving = false;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float pushMoveSpeed = 2.5f;
    protected bool isGrounded = true;
    protected Transform camTransform;
    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadPlayerCtrl();
    }
    protected void FixedUpdate()
    {
        this.HandelMoving();
        //this.IsMoving();
        this.IsJump();
    }
    protected void Start()
    {
        camTransform = Camera.main.transform;
    }
    protected void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground")) {
            this.isGrounded = true;
        }
    }
    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
    protected virtual void HandelMoving()
    {
        Vector3 camForward = camTransform.forward;
        Vector3 camRight = camTransform.right;

        camForward.y = 0f;
        camRight.y = 0f;

        camForward.Normalize();
        camRight.Normalize();

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = camForward * moveVertical + camRight * moveHorizontal;
        move = move.normalized;
        if (move == Vector3.zero) this.playerCtrl.Animator.SetBool("isMoving", false);       
        else this.playerCtrl.Animator.SetBool("isMoving", true);
        float currentSpeed = playerCtrl.isPush ? pushMoveSpeed : moveSpeed;
        playerCtrl.Rigidbody.MovePosition(transform.position + move * Time.fixedDeltaTime * currentSpeed);
        HandleRotation(move);
    }
    protected virtual void IsJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            playerCtrl.Rigidbody.AddForce(new Vector3(0f, 1f, 0f) * 1, ForceMode.Impulse);
            playerCtrl.Animator.SetBool("isJump", true);
            isGrounded = false;
        }
    }
    protected virtual void HandleRotation(Vector3 playerMove)
    {
        Vector3 lookDirection = playerMove;
        lookDirection.y = 0f;
        if(lookDirection != Vector3.zero)
        {
         Quaternion quaternion = Quaternion.LookRotation(lookDirection);
            transform.parent.rotation = quaternion;
        }
    }
}
