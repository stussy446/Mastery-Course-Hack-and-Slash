using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private Controller controller;
    private Animator animator;

    [SerializeField] private float moveSpeed = 5f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();   
    }

    internal void SetController(Controller controller)
    {
        this.controller = controller;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = controller.GetDirection();
        Vector3 direction = new Vector3(movement.x, 0, movement.y);
        transform.position += direction * Time.deltaTime * moveSpeed;
        if (direction != Vector3.zero)
        {
            transform.forward = direction * 360f;

            animator.SetFloat("Speed", direction.magnitude);
        }
        else
        {
            animator.SetFloat("Speed", 0);
        }
        
    }

}
