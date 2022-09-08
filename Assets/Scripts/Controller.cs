using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerControls))]
public class Controller : MonoBehaviour
{
    private InputActionMap player;
    private InputAction move;
    private InputActionAsset inputAsset;
    private bool attack1Pressed = false;

    public Vector2 MoveInputValue { get; private set; }
    public int Index { get; private set; }

    private void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        player = inputAsset.FindActionMap("Player");
    }

    private void Start()
    {
        Index = FindObjectsOfType<Controller>().Length;
    }

    private void OnEnable()
    {
        player.FindAction("Attack1").performed += Attack1;
        player.FindAction("Attack2").performed += Attack2;
        move = player.FindAction("Move");
        player.Enable();
    }

    private void Update()
    {
        MoveInputValue = move.ReadValue<Vector2>();
            
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnDisable()
    {
        player.FindAction("Attack1").performed -= Attack1;
        player.FindAction("Attack2").performed -= Attack2;
        player.Disable();
    }

    private static void Move()
    {
        // stuff
    }

    private void Attack1(InputAction.CallbackContext obj)
    {
        attack1Pressed = !attack1Pressed;
    }

    private void Attack2(InputAction.CallbackContext obj)
    {
    }


    internal bool Attack1Pressed()
    {
        return attack1Pressed;
    }
}