using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Componentes
    public CharacterController playerController;

    //Variáveis de movimento
    public float speed;
    public float gravity;
    public float jumpForce;
    private float inputX;
    private float inputZ;
    private Vector3 direction;
    // O Start  é chamado antes do primeiro frame
    void Start()
    {

    }

    // Update é chamado a cada frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        direction = new Vector3(inputX, 0, inputZ);

        if (Input.GetButtonDown("Jump"))
        {
            direction.y += jumpForce;
        }

        direction.y -= gravity * Time.deltaTime;

        playerController.Move(direction * speed * Time.deltaTime);
    }
}