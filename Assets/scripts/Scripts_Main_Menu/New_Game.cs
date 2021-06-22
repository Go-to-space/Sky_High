using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Game : MonoBehaviour
{
 public void NextScene(string Level_1)
    {
        SceneManager.LoadScene(Level_1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
