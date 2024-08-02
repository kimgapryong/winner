using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [System.Serializable]
    public struct enemyData
    {
        public GameObject enemyobj;
        public string name;
        public int health;
        public float speed;

    }

    [System.Serializable]
    public struct bossData
    {
        public GameObject bossobj;
        public int health;
       
    }


    public bossData[] bossDatas;
    public enemyData[] enemyDatas;

    public bossData SetBossData(BossCheckClass.Boss bossType)
    {
        switch(bossType)
        {
            case BossCheckClass.Boss.Boss1:
                
                return bossDatas[0];
                
            case BossCheckClass.Boss.Boss2:
                
                return bossDatas[1];
            default:
                return new bossData();
        }
        
    }

    

    private const float ValueMinus = 0.3f;
    private int scoreValue = 100;
    private float minRand = 1.7f;
    private float maxRand = 2f;
    private void Start()
    {
        StartCoroutine(RandomSpwaner());
    }

    private void EnemyCreate()
    {
        int value = 0;
        int RandomValue = Random.Range(0, 100);
        float newX = Random.Range(-2f, 2f), newY = Random.Range(7f, 9f);
        if(RandomValue <= 70)
        {
            value = 0;
        }else if(RandomValue <= 95)
        {
            value = 1;
        }
        else
        {
            value = 2;
        }
        GameObject clone = Instantiate(enemyDatas[value].enemyobj, new Vector3(newX, newY), Quaternion.identity);
        if(clone != null )
        {
            Rigidbody2D rigid = clone.AddComponent<Rigidbody2D>();
            CircleCollider2D collider =  clone.AddComponent<CircleCollider2D>();
            clone.AddComponent<EnemyDestroy>();
            clone.AddComponent<EnemyDieItem>();
            
            clone.gameObject.name = enemyDatas[value].name; 
        }
    } 
    

    
    private IEnumerator RandomSpwaner()
    {
        while(true)
        {
            EnemyCreate();
            if(GameManager.Instance.uiManager.score >= scoreValue)
            {
                scoreValue *= 2;
                minRand -= ValueMinus;
                maxRand -= ValueMinus;
            }
            yield return new WaitForSeconds(Random.Range(minRand, maxRand));

        }
    }
}
