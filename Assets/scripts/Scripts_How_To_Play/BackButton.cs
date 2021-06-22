using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Code To Get Back To Main Menu.(Back Button)
public class BackButton : MonoBehaviour
{
  public void PreviousScene(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
