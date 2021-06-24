using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Reset_Button1 : MonoBehaviour
{
    public void RestartGame(string Level_1)
    {
        SceneManager.LoadScene(Level_1);
    }
}
