using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public Rigidbody2D PlayerBody; // the rigidbody of the player
    public float MoveSpeed = 5f; // The movement speed of the player
    
    public float JumpForce = 2f; // How strong your jump is
    public Transform feet; // Placement of the feet
    public LayerMask groundLayers;
    
    float MoveInput; // varibale used to check which input is given

    // Update is called once per frame
    void Update()
    {
        MoveInput = Input.GetAxisRaw("Horizontal"); // gives a number of -1 to 1 for input on A and D or left and right on the keyboard

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump(); // use the function Jump
        }
    }
    // fixed update is used for physic based movement
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(MoveInput * MoveSpeed, PlayerBody.velocity.y); // Creates a movement 

        PlayerBody.velocity = movement; // 
    }

    void Jump()
    {
        Vector2 movement = new Vector2(PlayerBody.velocity.x, JumpForce);

        PlayerBody.velocity = movement;
    }

    public bool IsGrounded ()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers); // check were the feet are and if they touch the ground

        if (groundCheck != null) // checks if you are touching the ground
        {
            return true;
        }
        
        return false; // If you are not touching the ground give back false
    }
}
