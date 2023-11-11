using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMotion : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector3 direction;
    [SerializeField] Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0, vertical);
        //Movement
        if (horizontal != 0 || vertical != 0)
        {
            animator.SetBool("isMoving", true);
            //Rotation
            Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("kick");
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("head");
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
        }


    }

}
