using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject player;
    private CharacterController controller;
    private Animator playerAnim;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float playerRotSpeed;
    [SerializeField] private float gravity;

    private float moveX;
    private float moveZ;

    private Vector3 v_movement;
    private Vector3 v_velocity;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        controller = GetComponent<CharacterController>();
        playerAnim = transform.GetChild(0).GetComponent<Animator>();
    }
    private void Update()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        if (controller.isGrounded)
        {
            v_velocity.y = -2f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                v_velocity.y = 10f;
            }
        }
        else
        {
            v_velocity.y += gravity * 5 * Time.deltaTime;
        }



        controller.Move(v_velocity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        //Gravity


        //move forward && Backward
        v_movement = controller.transform.forward * moveZ;
        

        //Char Rotate
        controller.transform.Rotate(Vector3.up * moveX * (playerRotSpeed * Time.deltaTime));

        controller.Move(v_movement * moveSpeed * Time.deltaTime);
        
    }
}
