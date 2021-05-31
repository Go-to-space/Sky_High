using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terminal_UI_Trigger : MonoBehaviour
{
    public GameObject Console_UI; //The Scene that will pop-up when you go in the trigger


    private void OnTriggerEnter2D(Collider2D other) // If the 'Player' enters the trigger the scene will appear
    {
        if (other.gameObject.tag == "Player")
        {
            Console_UI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision) // If the 'Player' exits the trigger the scene will disappear
    {
        if (collision.gameObject.tag == "Player")
        {
            Console_UI.SetActive(false);
        }
    }
}
