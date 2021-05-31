using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Opener : MonoBehaviour
{
    public GameObject PivotPoint;

    bool DoorOpen = false;
    int i = 0;
    private float DoorSizeY;

    private void Start()
    {
        DoorSizeY = gameObject.transform.localScale.y;
    }
    public void Move()
    {
        if (DoorOpen == false)
        {
            StartCoroutine(MoveCoroutineOne());
        }
        else if (DoorOpen == true)
        {
            StartCoroutine(MoveCoroutineTwo());
        }
    }

    public IEnumerator MoveCoroutineOne()
    {
        while (i < DoorSizeY * 10)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0, 0.1f, 0);
            i++;
            yield return null;
        }
        DoorOpen = true;
    }
    public IEnumerator MoveCoroutineTwo()
    {
        while (i > 0)
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0, -0.1f, 0);
            i--;
            yield return null;
        }
        DoorOpen = false;
    }

    public void MoveRotate()
    {
        if (DoorOpen == false)
        {
            StartCoroutine(MoveRotateCoroutineOne());
        }
        else if (DoorOpen == true)
        {
            StartCoroutine(MoveRotateCoroutineTwo());
        }
    }
    public IEnumerator MoveRotateCoroutineOne()
    {
        while (i <= 90)
        {
            PivotPoint.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 0, i));
            i++;
            yield return null;
        }
        DoorOpen = true;
    }
    public IEnumerator MoveRotateCoroutineTwo()
    {
        i = 90;
        while (i >= 0)
        {
            PivotPoint.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 0, i));
            i--;
            yield return null;
        }
        DoorOpen = false;
    }
}
