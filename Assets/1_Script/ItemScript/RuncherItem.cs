using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuncherItem : Items
{
   
    private void Start()
    {
        itemName = "runcherItem";
       
    }
    private void Update()
    {
        MoveItem();
    }
    protected override void MoveItem()
    {
        transform.Translate(Vector2.down * 3f * Time.deltaTime);
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.attack.runcherValue += 1;
            Destroy(gameObject);
        }
    }


}
