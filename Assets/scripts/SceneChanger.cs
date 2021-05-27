using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string NextSceneName;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            NewScene();
        }
    }

    public void NewScene()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
