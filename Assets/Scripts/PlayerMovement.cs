using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
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
        playerController.Move(direction);
    }
}
