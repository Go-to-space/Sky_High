using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Sound : MonoBehaviour
{
    private AudioSource ButtonAudio;

    private void Start()
    {
        ButtonAudio = GetComponent<AudioSource>();
        ButtonAudio.Stop();
    }
    public void ButtonSound()
    {
        ButtonAudio.Play();
    }
}
