using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public Rigidbody2D PlayerBody; // the rigidbody of the player

    [SerializeField] private bool character_switch; // Check if movement is swapped
    [SerializeField] private float JumpForce = 2f; // How strong your jump is
    [SerializeField] private float MoveSpeed = 5f; // The movement speed of the player
    [SerializeField] private bool flipped;

    public LayerMask groundLayers;
    public Animator astro_animations;
    public Collider2D robot;
    public Collider2D astronaut;
    public BoxCollider2D boxCollider2D;

    float MoveInput; // Varibale used to check which input is given

    private void Start()
    {
        Physics2D.IgnoreCollision(robot, astronaut); // The colliders of the robot and astonaut while ignore each other.
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("switch")) // // By pressing tab you swapp the controls of the players.
        {
            this.character_switch = !this.character_switch;
        }

        if (character_switch == true)
        {
            MoveInput = Input.GetAxisRaw("Horizontal"); // W and d key movement
        } else {
            MoveInput = Input.GetAxisRaw("Horizontal2"); // Left and right arrow key movement 
        }
        
        if (Input.GetButtonDown("Jump") && IsGrounded()) // If grounded is true lets you jump
        {
            Jump(); // Use the function Jump
            astro_animations.SetTrigger("Hopping");
        }
    }
    // Fixed update is used for physic based movement
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(MoveInput * MoveSpeed, PlayerBody.velocity.y); // Creates a movement 

        PlayerBody.velocity = movement; // 

        astro_animations.SetFloat("Horizontal", movement.x);
        astro_animations.SetFloat("Speed", movement.sqrMagnitude);
        
        if ((movement.x < 0 && flipped == false) || (movement.x > 0 && flipped == true))
        {
            transform.Rotate(new Vector3(0, 180, 0));
            flipped = !flipped;
        }
    }

    void Jump()
    {
        Vector2 movement = new Vector2(PlayerBody.velocity.x, JumpForce); // Creates upwards momentum for a jump.

        PlayerBody.velocity = movement;
    }

    public bool IsGrounded ()
    {
        float extraheighttext = 0.1f;
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, extraheighttext, groundLayers); // Checks if the feet are touching the ground layer.

        if (raycastHit.collider != null) // Checks if you are touching the ground
        {
            astro_animations.SetBool("Landed", true);
            return true;
        }
        astro_animations.SetBool("Landed", false);
        return false; // If you are not touching the ground give back false
    }
}
