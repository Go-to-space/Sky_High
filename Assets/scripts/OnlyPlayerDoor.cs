using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyPlayerDoor : MonoBehaviour
{
    public GameObject player;
    public GameObject Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(Door.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
    }
}
