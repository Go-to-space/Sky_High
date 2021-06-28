using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robot_movement : MonoBehaviour
{
    // all the needed varibles
    public float MoveSpeed = 5f;
    public bool character_switch = false;
    public bool flipped;

    public Rigidbody2D PlayerBody;
    public Animator Robot_animations;
    public Animator Robot_reveresed;
    public GameObject robotRight;
    public GameObject robotLeft;

    Vector2 movement = Vector2.zero;

    void Start()
    {
        robotLeft.SetActive(false);
        robotRight.SetActive(true);
    }

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

        // plays first idle animation to force the robot to keep the fixed idle animation.
        // before switching to the other side.
        if (movement.x < 0 && flipped == false)
        {
            Robot_animations.Play("Idle");
            StartCoroutine(moveLeft());
        }
        if (movement.x > 0 && flipped == true)
        {
            Robot_reveresed.Play("Idle 0");
            StartCoroutine(moveRight());
        }
        
        // sets varibales that you can use in the animator for animation state
        Robot_animations.SetFloat("Horizontal", movement.x);
        Robot_animations.SetFloat("Vertical", movement.y);
        Robot_animations.SetFloat("Speed", movement.sqrMagnitude);
        Robot_animations.SetBool("Flipped", flipped);

        Robot_reveresed.SetFloat("Horizontal", movement.x);
        Robot_reveresed.SetFloat("Vertical", movement.y);
        Robot_reveresed.SetFloat("Speed", movement.sqrMagnitude);
        Robot_reveresed.SetBool("Flipped", flipped);
    }
    void FixedUpdate()
    {
        // Lets the player move plus it lets the player interact correctly with the platform
        this.transform.position += (Vector3)(movement * MoveSpeed * Time.fixedDeltaTime);
    }

    IEnumerator moveLeft()
    {
        /* this part of the code while exucte later than the animation
        * this is to fix a bug that would let the robot stay in his prevouis animation state after switching
        */
        yield return new WaitForSeconds(0.01f);
        robotLeft.SetActive(true);
        robotRight.SetActive(false);
        flipped = true;
    }

    IEnumerator moveRight() 
    {
        /* this part of the code while exucte later than the animation
         * this is to fix a bug that would let the robot stay in his prevouis animation state after switching
         */
        yield return new WaitForSeconds(0.01f);
        robotLeft.SetActive(false);
        robotRight.SetActive(true);
        flipped = false;
    }
}
