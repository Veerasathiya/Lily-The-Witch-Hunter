using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    private CharacterController controller;
    private Animator[] playerAnim;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rotSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpLength;

    private float moveZ;
    private float moveX;

    private Vector3 moveAxis;
    private Vector3 velocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerAnim = GetComponentsInChildren<Animator>();
    }

    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        PlayerManager();
    }

    void PlayerManager()
    {
        moveAxis = controller.transform.forward * moveZ;
        if(controller.isGrounded)
        {
            velocity.y = -2f;
        }

        if(controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump(true);
            }else
            {
                Jump(false);
            }
        }

        if(moveAxis != Vector3.zero)
        {
            Walk(true);

        }
        else
        {
            Walk(false);
        }
        if (moveAxis != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
        {
            Run(true);
        }
        else
        {
            Run(false);
        }
        if (moveAxis != Vector3.zero && Input.GetKeyDown(KeyCode.Space))
        {
            WalkJump(true);
        }else
        {
            WalkJump(false);
        }
        if(moveX > 0 || moveX < 0)
        {
            Walk(true);
        }
        if (moveAxis != Vector3.zero && Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space))
        {
            RunJump(true);
        }
        else
        {
            RunJump(false); 
        }


        if (moveX > 0 || moveX < 0)
        {
            if(moveAxis != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run(true);
            }
            else
            {
                Walk(true);
            }
            
        }


        velocity.y += gravity * 10 * Time.deltaTime; 

        controller.transform.Rotate(Vector3.up, moveX * (rotSpeed * Time.deltaTime));

        controller.Move(moveAxis * moveSpeed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);


    }

    void Walk(bool walkOn)
    {
        if(walkOn)
        {
            moveSpeed = walkSpeed;
        }
        
        playerAnim[0].SetBool("Walk", walkOn);
    }

    void WalkJump(bool _ON)
    {
        playerAnim[0].SetBool("Walkjump", _ON);
    }
    void RunJump(bool _ON)
    {
        playerAnim[0].SetBool("Runjump", _ON);
    }
    void Run(bool runOn)
    {
        if(runOn)
        {
            moveSpeed = runSpeed;
        }

        playerAnim[0].SetBool("Run", runOn);
    }

    void Jump(bool jumpOn)
    {
        if(jumpOn)
        {
            velocity.y = Mathf.Sqrt(jumpLength * -2 * gravity);
        }
        
        playerAnim[0].SetBool("Jump", jumpOn);
    }
}
