using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Reset_Button2 : MonoBehaviour
{
 public void RestartGame(string Level_2)
    {
        SceneManager.LoadScene(Level_2);
    }  
}
