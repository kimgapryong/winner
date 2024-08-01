using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUpItem : Items
{
    private UIManager manager;

    private void Start()
    {
        manager = GameObject.Find("UiManager").GetComponent<UIManager>();
    }
    private void Update()
    {
        MoveItem();
    }
    protected override void MoveItem()
    {
        transform.position += Vector3.down * 4.5f * Time.deltaTime;
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            manager.health += 1;
            Destroy(gameObject);
        }
    }
}
