using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float horizontal;
    float vertical;
    Vector3 direction;
    [SerializeField] float speed;

    [SerializeField] CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        direction = new Vector3(horizontal, 0, vertical);

        if (controller.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                direction.y = 1;
            }
        }
        else
        {
            direction.y -= 9.8f * Time.deltaTime;
        }

        controller.Move(direction * speed * Time.deltaTime);

    }

}
