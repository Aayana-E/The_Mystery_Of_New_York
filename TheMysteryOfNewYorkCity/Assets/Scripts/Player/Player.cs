using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("PlayerMovement Variables")]
    //[SerializeField] private bool invertControls = false; //check which player to invert controls for

    [SerializeField] private Rigidbody2D controller;
    [SerializeField] private float speed = 6f;// Player movement speed

    float horizontal;
    float vertical;

    void Start()
    {
        controller = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Get input for horizontal and vertical movement
         horizontal = Input.GetAxisRaw("Horizontal");
         vertical = Input.GetAxisRaw("Vertical");

        // Calculate the new position based on input and speed
        //Vector3 newPosition = transform.position + new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;

        // Move the player to the new position
        //transform.position = newPosition;
    }

    private void FixedUpdate()
    {
        controller.velocity = new Vector2(horizontal * speed, vertical * speed);
    }
}
