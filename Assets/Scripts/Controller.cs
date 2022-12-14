using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerControls))]
public class Controller : MonoBehaviour
{
    private InputActionAsset inputAsset;
    private InputActionMap player;
    private InputAction move;

    public int Index { get; private set; }

    private void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
    }

    private void Start()
    {
        Index = FindObjectsOfType<Controller>().Length + 1;
    }

    private void OnEnable()
    {
        player.FindAction("Attack1").performed += Attack1;
        player.FindAction("Attack2").performed += Attack2;
        move = player.FindAction("Move");
        player.Enable();
    }

    private void OnDisable()
    {
        player.FindAction("Attack1").performed -= Attack1;
        player.FindAction("Attack2").performed -= Attack2;
        player.Disable();
    }

    private void Attack1(InputAction.CallbackContext obj)
    {
        GetComponent<Transform>().position += Vector3.up;
    }

    private void Attack2(InputAction.CallbackContext obj)
    {
        GetComponent<Transform>().position += Vector3.down;
    }
}