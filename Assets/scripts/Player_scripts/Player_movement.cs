using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public Rigidbody2D PlayerBody; // the rigidbody of the player
    public float MoveSpeed = 5f; // The movement speed of the player
    public bool character_switch; // check if movement is swapped
    
    public float JumpForce = 2f; // How strong your jump is
    public Transform feet; // Placement of the feet
    public LayerMask groundLayers;
    public Collider2D robot;
    public Collider2D astronaut;

    float MoveInput; // varibale used to check which input is given

    private void Start()
    {
        Physics2D.IgnoreCollision(robot, astronaut); // The colliders of the robot and astonaut while ignore each other.
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("switch"))
        {
            this.character_switch = !this.character_switch;
        }

        if (character_switch == true)
        {
            MoveInput = Input.GetAxisRaw("Horizontal"); // gives a number of -1 to 1 for input on A and D or left and right on the keyboard
        } else
        {
            MoveInput = Input.GetAxisRaw("Horizontal2"); // gives a number of -1 to 1 for input on A and D or left and right on the keyboard
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) // if grounded is true lets you jump
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
        Vector2 movement = new Vector2(PlayerBody.velocity.x, JumpForce); // creates upwards momentum for a jump.

        PlayerBody.velocity = movement;
    }

    public bool IsGrounded ()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayers); // checks if the feet are touching the ground layer.

        if (groundCheck != null) // checks if you are touching the ground
        {
            return true;
        }
        
        return false; // If you are not touching the ground give back false
    }
}
