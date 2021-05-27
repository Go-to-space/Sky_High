using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnlyPlayerDoor : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
        }
    }
}
