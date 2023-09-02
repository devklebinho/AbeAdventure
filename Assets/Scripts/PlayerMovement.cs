using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;

    private float inputX;
    private float inputZ;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        direction = new Vector3(inputX, 0, inputZ);
        
        if(playerController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("Jump");
                direction.y += jumpSpeed;
            }
        }

        direction.y -= gravity * Time.deltaTime;

        playerController.Move(direction * moveSpeed * Time.deltaTime);
    }
}
