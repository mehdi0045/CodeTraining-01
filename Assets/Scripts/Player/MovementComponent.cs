using UnityEngine;

public class MovementComponent
{
    public MovementComponent(float moveSpeed, float turnSmothVelocity, CharacterController controller, Transform camTransform, Transform transform)
    {
        this.moveSpeed = moveSpeed;
        this.turnSmothVelocity = turnSmothVelocity;
        this.controller = controller;
        this.camTransform = camTransform;
        this.transform = transform;
    }
    
    private float moveSpeed;
    private float turnSmothVelocity;
    
    private CharacterController controller;
    private Transform camTransform;
    private Transform transform;

    public void Move(Animator animator)
    {
        animator.SetInteger("State",0);

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(h , 0f ,v).normalized;
        
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmothVelocity,0.1f);
            transform.rotation = Quaternion.Euler(0f,angle,0f);
            animator.SetInteger("State",1);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }
            
    }
}
