using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_movement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public bool character_switch;

    public Rigidbody2D PlayerBody;
    public Animator Robot_animations;

    Vector2 movement = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("switch")) // By pressing tab you swapp the controls of the players.
        {
            this.character_switch = !this.character_switch; // By pressing tab you toggle character switch form true to false and vis versa.
        }

        // Uses the unity's input manager to read the inputs
        // Convert this inputs into movement over the x and y directions
        if (character_switch == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal2"); // left and right arrow key movement
            movement.y = Input.GetAxisRaw("Vertical2"); // Up and down arrow key movement
        } else {
            movement.x = Input.GetAxisRaw("Horizontal"); // W and d key movement
            movement.y = Input.GetAxisRaw("Vertical"); // Up and down arrow key movement
        }
        Robot_animations.SetFloat("Horizontal", movement.x);
        Robot_animations.SetFloat("Vertical", movement.y);
        Robot_animations.SetFloat("Speed", movement.sqrMagnitude);
    }
    void FixedUpdate()
    {
        // Lets the player move plus it lets the player interact correctly with the platform
        this.transform.position += (Vector3)(movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
