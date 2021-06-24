using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_character : MonoBehaviour
{
    public GameObject Astronaut_selected;
    public GameObject Robot_selected;
    public GameObject None_selected;

    public robot_movement robot_move;

    // Start is called before the first frame update
    void Start()
    {
        None_selected.SetActive(true);
        Robot_selected.SetActive(false);
        Astronaut_selected.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (robot_move.character_switch == true)
        {
            None_selected.SetActive(false);
            Robot_selected.SetActive(true);
            Astronaut_selected.SetActive(false);
        } else {
            None_selected.SetActive(false);
            Robot_selected.SetActive(false);
            Astronaut_selected.SetActive(true);
        }
    }
}
