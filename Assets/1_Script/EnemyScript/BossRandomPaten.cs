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


 
    public bool isMove = false;
    private bool isBody = false;

    private Vector2 shipPos;
    private Vector2 targetPos = new Vector2(0, -3.5f);

    public BossPaten.BossAttack bossPaten;

    private void Start()
    {
        shipPos = transform.position;
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
        if (isMove)
        {
            if(transform.position.y >= -3.5f)
            {
                transform.Translate(Vector2.down * 35f * Time.deltaTime);
            }
            else
            {
                StartCoroutine(goStartPos());
            }
            
        }
        
    }
    private IEnumerator goStartPos()
    {
        while(transform.position.y < shipPos.y)
        {
            transform.Translate(Vector2.up * 8 * Time.deltaTime);
            yield return null;
            if (transform.position.y >= shipPos.y)
            {
                isMove = false;
                break;
            }
        }
    }
    private IEnumerator StartBossAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 2f));
            RandomAttackValue = Random.Range(0, BossPatenValue);
            switch (RandomAttackValue)
            {
                case 0:
                    bossPaten = BossPaten.BossAttack.Bullet;
                    StartCoroutine(bossAttack.BossBulletator());
                    
                    break;
                case 1:
                    bossPaten = BossPaten.BossAttack.Body;
                    isBody = true;
                    break;
                case 2:
                    bossPaten = BossPaten.BossAttack.Runcher;
                    StartCoroutine(bossAttack.BossRuncherAttack());
                    break;
            }
            RandomAttackValue = BossPatenValue + 1;
            yield return new WaitForSeconds(2f);
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
