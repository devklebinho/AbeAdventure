using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMotion : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector3 direction;
    [SerializeField] Animator animator;
    public bool canWalk;
    void Start()
    {
        animator = GetComponent<Animator>();
        canWalk = true;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0, vertical);
        //Movement
        if ((horizontal != 0 || vertical != 0) && canWalk == true)
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
            StartCoroutine(Attack());
        }

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("head");
            StartCoroutine(Head());
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetTrigger("jump");
            StartCoroutine(Jump());
        }
    }

    IEnumerator Jump()
    {
        canWalk = false;
        yield return new WaitForSeconds(1.0f);
        canWalk = true;
    }

    IEnumerator Attack()
    {
        canWalk = false;
        yield return new WaitForSeconds(1.0f);
        canWalk = true;
    }

    IEnumerator Head()
    {
        canWalk = false;
        yield return new WaitForSeconds(1.0f);
        canWalk = true;
    }

}
