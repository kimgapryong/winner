using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkilesBullet : MonoBehaviour
{
    private void Update()
    {
        transform.Translate(Vector3.up * 3f * Time.deltaTime);
        if(transform.position.y >= 5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
