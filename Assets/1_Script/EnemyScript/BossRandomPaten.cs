using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossRandomPaten : MonoBehaviour
{
    private int RandomAttackValue;
    private int BossPatenValue;
    private BossAttackPaten bossAttack;

    private bool isBody = false;
    public BossPaten.BossAttack bossPaten;

    private void Start()
    {
        BossPatenValue = Enum.GetValues(typeof(BossPaten.BossAttack)).Length;
        RandomAttackValue = Random.Range(0, BossPatenValue);
        bossAttack = GetComponent<BossAttackPaten>();
        StartCoroutine(StartBossAttack());

    }
    private void Update()
    {
        if (isBody)
        {
            isBody = false;
            StartCoroutine(bossAttack.Bossbodytor());
            
        }
        if (transform.position.y > -3.4f)
        {
            transform.Translate(Vector2.down * 35 * Time.deltaTime);
        }
        else if (transform.position.y < -3.4f)
        {
            transform.Translate(Vector2.up * 4 * Time.deltaTime);
            if (transform.position.y >= 4)
            {
                transform.position = new Vector3(transform.position.x, 4, 0);
                
            }
        }
    }

    private IEnumerator StartBossAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 4f));
            RandomAttackValue = 1;
            switch (RandomAttackValue)
            {
                case 0:
                    bossPaten = BossPaten.BossAttack.Bullet;
                    RandomAttackValue = Random.Range(0, BossPatenValue);
                    StartCoroutine(bossAttack.BossBulletator());
                    break;
                case 1:
                    bossPaten = BossPaten.BossAttack.Body;
                    isBody = true;
                    RandomAttackValue = Random.Range(0, BossPatenValue);
                    break;
                case 2:
                    bossPaten = BossPaten.BossAttack.Runcher;
                    RandomAttackValue = Random.Range(0, BossPatenValue);
                    break;
            }
            RandomAttackValue = BossPatenValue + 1;
            yield return new WaitForSeconds(3);
           
        }
    }
}
public class BossPaten
{
    public enum BossAttack
    {
        Bullet,
        Body,
        Runcher
    }
}
