using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerControls))]
public class Controller : MonoBehaviour
{
    private InputAction move;
    private InputActionAsset inputAsset;

    public Vector2 MoveInputValue { get; private set; }
    public int Index { get; private set; }
    public bool Attack1Pressed { get; private set; }
    public bool ReadyToStart { get; private set; }
    public InputActionMap Player { get; private set; }
    


    private void Awake()
    {
        inputAsset = GetComponent<PlayerInput>().actions;
        Player = inputAsset.FindActionMap("Player");
    }

    private void Start()
    {
        Index = FindObjectsOfType<Controller>().Length;
    }

    private void OnEnable()
    {
        Player.FindAction("Attack1").performed += Attack1;
        Player.FindAction("Attack1").canceled += Attack1Ended;
        Player.FindAction("Start").performed += HandleStart;
        Player.FindAction("Attack2").performed += Attack2;
        move = Player.FindAction("Move");
        Player.Enable();
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
        Player.FindAction("Attack1").performed -= Attack1;
        Player.FindAction("Attack1").canceled -= Attack1Ended;
        Player.FindAction("Start").performed -= HandleStart;
        Player.FindAction("Attack2").performed -= Attack2;
        Player.Disable();
    }

    internal Vector2 GetDirection()
    {
        return move.ReadValue<Vector2>();
    }

    private static void Move()
    {
        // stuff
    }

    private void Attack1(InputAction.CallbackContext obj)
    {
        Attack1Pressed = true;
    }

    private void Attack1Ended(InputAction.CallbackContext obj)
    {
        Attack1Pressed = false;
    }


    private void Attack2(InputAction.CallbackContext obj)
    {
    }

    private void HandleStart(InputAction.CallbackContext obj)
    {
        ReadyToStart = true;
    }



}