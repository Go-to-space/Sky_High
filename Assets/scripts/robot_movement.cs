using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_movement : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public bool character_switch;

    public Rigidbody2D PlayerBody;

    Vector2 movement = Vector2.zero;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("switch"))
        {
            this.character_switch = !this.character_switch;
        }

        // uses the unity's input manager to read the inputs
        // convert this inputs into movement over the x and y directions
        if (character_switch == true)
        {
            movement.x = Input.GetAxisRaw("Horizontal2");
        } else
        {
            movement.x = Input.GetAxisRaw("Horizontal");
        }
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate()
    {
        // Lets the player move plus it lets the player interact correctly with the platform
        this.transform.position += (Vector3)(movement * MoveSpeed * Time.fixedDeltaTime);
    }
}
