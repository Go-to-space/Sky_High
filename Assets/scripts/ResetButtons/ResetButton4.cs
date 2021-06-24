using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton4 : MonoBehaviour
{
 public void Resetgame(string Level_4)
    {
        SceneManager.LoadScene(Level_4);
    }  
}
