using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Opener : MonoBehaviour
{
    public GameObject PivotPoint;
    private AudioSource OpenAudio;

    public bool DoorOpen;
    public bool RotateMin;

    float i = 0;
    private float DoorSizeY;

    private void Start()
    {

        OpenAudio = GetComponent<AudioSource>();
        DoorSizeY = gameObject.transform.localScale.y;
    }
    public void Move()
    {
        if (DoorOpen == false)
        {
            OpenAudio.Play();
            StartCoroutine(MoveCoroutineOne());
        }
        else if (DoorOpen == true)
        {
            OpenAudio.Play();
            i = DoorSizeY * 10;
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
        if (RotateMin == false)
        {
            while (i <= 90)
            {
                PivotPoint.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 0, i));
                i++;
                yield return null;
            }
            DoorOpen = true;
        }

        if (RotateMin == true)
        {
            while (i >= -90)
            {
                PivotPoint.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 0, i));
                i--;
                yield return null;
            }
            DoorOpen = true;
        }

    }
    public IEnumerator MoveRotateCoroutineTwo()
    {
        if (RotateMin == false)
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

        if (RotateMin == true)
        {
            i = -90;
            while (i <= 0)
            {
                PivotPoint.GetComponent<Transform>().rotation = Quaternion.Euler(new Vector3(0, 0, i));
                i++;
                yield return null;
            }
            DoorOpen = false;
        }
    }
}
