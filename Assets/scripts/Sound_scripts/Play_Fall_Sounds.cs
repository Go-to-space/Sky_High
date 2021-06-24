using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Fall_Sounds : MonoBehaviour
{
    private AudioSource fallAudio;
    public Rigidbody2D rb;

    private bool Onground;
    private bool IsFalling;

    void Start()
    {
        fallAudio = GetComponent<AudioSource>(); // to get the audio source
    }
    private void Update()
    {
        if (rb.velocity.y < -10) // checks if the cube has been falling
        {
            IsFalling = true;
        }

        if (IsFalling == true && Onground == true) // If the cube touches the ground and has fallen it will play the sound
        {
            IsFalling = false; // resets the falling condision
            fallAudio.Play();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6) // If the cube is touching the ground 'Onground = true'
        {
            Onground = true;
        }
        if (collision.gameObject.layer != 6)
        {
            Onground = false;
        }
    }
}
