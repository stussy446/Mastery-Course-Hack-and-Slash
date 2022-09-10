using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private Controller controller;
    [SerializeField] private float moveSpeed = 5f;

    internal void SetController(Controller controller)
    {
        this.controller = controller;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement  = controller.Player.FindAction("Move").ReadValue<Vector2>();
        Vector3 direction = new Vector3(movement.x, 0, movement.y);
        transform.position += direction * Time.deltaTime * moveSpeed;
    }

}
