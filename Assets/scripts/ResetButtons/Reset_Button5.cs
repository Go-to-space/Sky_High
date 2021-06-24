using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset_Button5 : MonoBehaviour
{
  public void ResetGame(string Level_5)
    {
        SceneManager.LoadScene(Level_5);
    }
}
