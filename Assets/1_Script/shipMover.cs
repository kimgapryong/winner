using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipMover : MonoBehaviour
{
    private float speed = 3f;
    private float maxSpeed = 10f;
    private Rigidbody2D rigid;
    
    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    private void Update()
    {
        ShipMove();
    }

    private void ShipMove()
    {
        float moveX = 0f;
        float moveY = 0f;

        if(transform.gameObject != null)
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveX = -speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveX = speed;
            }

            if (Input.GetKey(KeyCode.W))
            {
                moveY = speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                moveY = -speed;
            }

            Vector2 moveVector = new Vector2(moveX, moveY);

            if (moveVector.magnitude > maxSpeed)
            {
                moveVector = moveVector.normalized * maxSpeed;
            }

            rigid.velocity = moveVector;

            if (transform.position.y <= -5)
            {
                transform.position = new Vector2(transform.position.x, -5);
            }
            else if (transform.position.y >= 5)
            {
                transform.position = new Vector2(transform.position.x, 5);
            }
        }
        
    }
}
