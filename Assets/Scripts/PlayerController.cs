using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Componentes
    public CharacterController playerController;
    public Animator anim;

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
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update é chamado a cada frame
    void Update()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");

        direction = new Vector3(inputX, 0, inputZ);

        if(playerController.isGrounded)//O player está no chão?
        {
            anim.SetBool("isJumping", false);//player no chão não está pulando

            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Attack());
            }
                

            //Correndo
            if (inputX == 0 && inputZ == 0)//o player está parado?
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
            //Pulo
            if (Input.GetButtonDown("Jump"))
            {
                direction.y += jumpForce;
                anim.SetBool("isJumping", true);
            }
        }

        //Rotação
        Vector3 lookDirection = new Vector3(direction.x, 0, direction.z);
        transform.rotation = Quaternion.LookRotation(lookDirection);

        //Gravidade
        direction.y -= gravity * Time.deltaTime;
        
        //Movimentação
        playerController.Move(direction * speed * Time.deltaTime);
    }

    //-----------------------------------------------------------------

    IEnumerator Attack()
    {
        anim.SetBool("isKick", true);
        yield return new WaitForSeconds(1.0f);
        anim.SetBool("isKick", false);
    }
}