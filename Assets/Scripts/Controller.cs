using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerControls))]
public class Controller : MonoBehaviour
{
    private PlayerControls playerControls;
    public int index;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        index = FindObjectsOfType<Controller>().Length;
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Attack1.performed += Attack1;
        playerControls.Player.Attack2.performed += Attack2;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Player.Attack1.performed -= Attack1;
        playerControls.Player.Attack2.performed -= Attack2;
    }

    private void Attack1(InputAction.CallbackContext obj)
    {
        Debug.Log("Attacking with Attack1");
    }

    private void Attack2(InputAction.CallbackContext obj)
    {
        Debug.Log("Attacking with Attack2");

    }
}