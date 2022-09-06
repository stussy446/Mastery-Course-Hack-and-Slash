using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    private PlayerControls playerControls;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        playerControls.Enable();
        playerControls.Player.Attack.performed += Attack;
    }

    private void OnDisable()
    {
        playerControls.Disable();
        playerControls.Player.Attack.performed += Attack;
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attacking");
        Debug.Log(obj);
    }
}
