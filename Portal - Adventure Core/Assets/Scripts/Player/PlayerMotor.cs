//Programmer: Rachel Huggins

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    //reference to the player's character controller
    private CharacterController controller;

    //leaving these fields to be adjustable later
    [Header("Player Physics")]
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpHeight = 3f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float gravity = -8.2f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    //recieving the inputs from the InputManager script and applying it to the character controller's physics
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.y = input.y;

        //something here might need to change the equation to 
        //(transform.TransformDirection(moveDirection) * speed) * Time.deltaTime
        //remembering something Zeb said about efficiency, need to ask <-----------
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);

        playerVelocity.y += gravity * Time.deltaTime;

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2.0f;
        }

        controller.Move(playerVelocity * Time.deltaTime);

        Debug.Log("How much force is being applied down onto the character: " + playerVelocity.y);
    }

    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -jumpHeight * gravity);
        }
    }
}
