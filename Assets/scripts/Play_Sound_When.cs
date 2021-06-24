using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play_Fall_Sound : MonoBehaviour
{
    private AudioSource fallAudio;
    private bool LetSoundPlay = false;
    // Start is called before the first frame update
    void Start()
    {
        fallAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 6)
        {
            LetSoundPlay = true;
            fallAudio.Pause();
        }

        if (collision.gameObject.layer == 6 && LetSoundPlay == true)
        {
            fallAudio.Play();
            Debug.Log("AUDIO PLAYING");
            //fallAudio.UnPause();

            if (collision.gameObject.layer != 6)
            {
                LetSoundPlay = true;
                fallAudio.Pause();
            }
            LetSoundPlay = false;
        }
    }
}
