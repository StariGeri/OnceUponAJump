using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float runSpeed = 6f;
    [SerializeField] private float jumpHeight = 2f;

    private float gravity = -50f;
    private CharacterController characterController;
    private Vector2 velocity;
    private bool isGrounded;
    private float horizontalInput;
    

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        horizontalInput = 1;

        transform.forward = new Vector2(horizontalInput, Mathf.Abs(horizontalInput) - 1);
        
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

        velocity.y += gravity * Time.deltaTime;


        if(isGrounded && velocity.y <0)
        {
            velocity.y = 0;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
        }
        characterController.Move(new Vector2(horizontalInput * runSpeed , 0) * Time.deltaTime);

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        characterController.Move(velocity * Time.deltaTime);
    }
}
