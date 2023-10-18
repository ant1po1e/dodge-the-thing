using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        Vector2 newPos = rb.position + Vector2.right * x;

        newPos.x = Mathf.Clamp(newPos.x, -mapWidth, mapWidth);

        rb.MovePosition(newPos);
    }

    void OnCollisionEnter2D()
    {
        FindObjectOfType<GameManager>().GameOver();
    }
}
