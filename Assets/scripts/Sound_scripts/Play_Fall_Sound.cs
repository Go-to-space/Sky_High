using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Sound_When : MonoBehaviour
{
    private AudioSource fallAudio;
    public Transform objct;
    public LayerMask groundLayers;
    private bool LetSoundPlay = false;

    void Start()
    {
        fallAudio = GetComponent<AudioSource>();
    }

    public bool IsGrounded()
    {
        Collider2D groundCheck = Physics2D.OverlapCircle(objct.position, 0.5f, groundLayers);

        if (groundCheck != null) // Checks if you are touching the ground
        {
            return true;
        }

        return false; // If you are not touching the ground give back false
    }

    public void fallingSound()
    {
        LetSoundPlay = IsGrounded();
        if (LetSoundPlay == true)
        {
            fallAudio.Play();
            LetSoundPlay = false;
        }
    }
}
