using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton_3 : MonoBehaviour
{
  public void ResetGame(string Level_3)
    {
        SceneManager.LoadScene(Level_3);
    }    
}
