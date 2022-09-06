using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Controller controller;

    public Player(Controller controller)
    {
        controller = GetComponent<Controller>();
    }

}
