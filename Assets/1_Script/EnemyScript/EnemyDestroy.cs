using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private Enemy enemyScript;
    private Rigidbody2D rb;
    private CircleCollider2D circleCollider;
    private EnemyDieItem enemyDieItem;

    private UIManager uiManager;
    public int health;
    public float speed;

    private bool bulletAttack = true;

    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        enemyDieItem = GetComponent<EnemyDieItem>();
        enemyScript = GameObject.Find("enemyCreate").GetComponent<Enemy>();
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
        health = GetHealth();
    }
    private void Update()
    {
        EnemyDelete();
        EnemyMove();
    }
    private void EnemyMove()
    {
        if(rb != null)
        {
            rb.gravityScale = 0;
            rb.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeRotationZ;
        }
        if(circleCollider != null)
        {
            circleCollider.isTrigger = true;
        }
        for(int i = 0; i < enemyScript.enemyDatas.Length; i++)
        {
            if(gameObject.name == enemyScript.enemyDatas[i].name)
            {
                if (gameObject.transform.position.y >= -5)
                {
                    
                    rb.velocity = new Vector2(0, -enemyScript.enemyDatas[i].speed);
                }
            }
        }
    }
    
    public int GetHealth()
    {
        for (int i = 0; i < enemyScript.enemyDatas.Length; i++)
        {
            if (gameObject.name == enemyScript.enemyDatas[i].name)
            {
                return enemyScript.enemyDatas[i].health;
            }
        }

        return 0;
    }
    private void EnemyDelete()
    {
        if (transform.position.y <= -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (bulletAttack)
            {
                bulletAttack = false;
                Destroy(collision.gameObject);
                if (health > 0)
                {
                    health--;
                    StartCoroutine(enemyTarget(gameObject));
                }
                else
                {
                    uiManager.score += GetHealth() ;
                    enemyDieItem.ItemCreate();
                    Destroy(gameObject);
                }
                
            }
            
            

        }
    }

    
  

    private IEnumerator enemyTarget(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
            
            yield return new WaitForSeconds(0.1f);
            renderer.enabled = true;
        }
       
        bulletAttack = true;
    }
}
