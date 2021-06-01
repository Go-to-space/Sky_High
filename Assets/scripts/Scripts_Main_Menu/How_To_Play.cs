using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class How_To_Play : MonoBehaviour
{
    public void NextScene(string HowToPlay)
    {
        SceneManager.LoadScene(HowToPlay);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
