using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Controller controller;
    private UIPlayerText uiPlayerText;

    public int Index { get; private set;}

    private void Awake()
    {
    }

    public Player(Controller controller)
    {
        Index = controller.Index;
        controller = GetComponent<Controller>();
    }

}
