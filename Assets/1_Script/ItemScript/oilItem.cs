using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class oilItem : Items
{
    
    private HealthBar healthBar;
    private bool isItem = true;

    

    private void Start()
    {
        itemName = "Oil";
        healthBar = GameObject.Find("oilBar").GetComponent<HealthBar>();
        
    }
    private void Update()
    {
        MoveItem();
    }
    protected override void MoveItem()
    {
        transform.position += Vector3.down * 3f * Time.deltaTime;
        if(transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(isItem)
            {
                isItem = false;
                healthBar.healthSlider.value += 0.07f;
                Destroy(gameObject);
            }
        }
    }
}
