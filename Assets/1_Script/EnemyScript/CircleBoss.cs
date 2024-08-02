using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBoss : MonoBehaviour
{
    public BossCheckClass.Boss BossType;
    private Enemy.bossData bossData;

    //GameManager »ç¿ë
    private UIManager uiManager;
    private Enemy enemyData;

    private int maxHealth;
    private int currentHealth;
    private bool isAttack = true;

    private void Start()
    {
        BossType = BossCheckClass.Boss.Boss1;

        enemyData = GameManager.Instance.enemy;
        uiManager = GameManager.Instance.uiManager;

        bossData = enemyData.SetBossData(BossType);

        maxHealth = bossData.health;
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") && isAttack)
        {
            isAttack = false;
            if(bossData.health > 0)
            {
                currentHealth--;
                uiManager.bossHealth.value = (float)currentHealth / maxHealth;
                bossData.health = currentHealth;

                StartCoroutine(BossTimeCheck());
                
            }
            else
            {
                Destroy(gameObject);
            }
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator BossTimeCheck()
    {
        
        yield return new WaitForSeconds(1f);
        isAttack = true;
    }
}

