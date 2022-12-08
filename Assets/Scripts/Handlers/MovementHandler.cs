using System;
using System.Collections.Generic;
using Handlers.Interfaces;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementHandler : MonoBehaviour , IHandler
{
    public Animator animator;
    private GameObject player;
    private float moveSpeed = 200;
    private Vector3 direction;
    private float turnSmothVelocity;
    
    public Transform camTransform;
    private Transform transform;
    public void Init(IController iController)
    {
    }

    public void Move(Rigidbody rb, Transform _transform)
    {
        if (direction.magnitude >= 1)
        {
            animator.SetInteger("State",1);
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + camTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(_transform.eulerAngles.y, targetAngle, ref turnSmothVelocity,0.1f);
            _transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f)*Vector3.forward;
            rb.velocity = moveDir * moveSpeed * Time.deltaTime;
        }
        else
        {
            animator.SetInteger("State",0);

        }
    }
    public void MoveInput(InputValue value)
    {
        direction = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }

    
    
}
