using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletItem : Items
{
    private void Start()
    {
        itemName = "BulletItem";
        
    }
    private void Update()
    {
        MoveItem();
    }
    protected override void MoveItem()
    {
        transform.Translate(Vector2.down * 3.7f * Time.deltaTime);
        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.attack.AttackCount += 1;
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("GameManager or Attack reference is missing.");
        }
        Destroy(gameObject);
    }
}
