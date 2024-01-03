using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 5f;

    private Rigidbody2D rb;
    private MobileInput input;
    private Vector2 moveVector = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (PowerUp.Instance.isSpeedUp == true)
        {
            speed = 30f;
        }
        else
        {
            speed = 15f;
        }

        Vector2 x = moveVector * Time.fixedDeltaTime * speed;
        Vector2 newPos = rb.position + Vector2.right * x;
        newPos.x = Mathf.Clamp(newPos.x, -mapWidth, mapWidth);
        rb.MovePosition(newPos);
    }

    void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().GameOver();
    }


    private void Awake()
    {
        input = new MobileInput();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCacelled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCacelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void OnMovementCacelled(InputAction.CallbackContext value)
    {
        moveVector = Vector2.zero;
    }
}
