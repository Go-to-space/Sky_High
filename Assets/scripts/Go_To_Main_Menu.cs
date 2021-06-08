using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Go_To_Main_Menu : MonoBehaviour
{
  public void ToMainMenu(string MainMenu)
    {
        SceneManager.LoadScene(MainMenu);
    }
}
