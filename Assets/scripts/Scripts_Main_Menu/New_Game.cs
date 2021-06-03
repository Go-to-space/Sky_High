using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class New_Game : MonoBehaviour
{
 public void NextScene(string Level1)
    {
        SceneManager.LoadScene(Level1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
