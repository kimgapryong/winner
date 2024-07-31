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
    public enemyData[] enemyDatas;

    private void Start()
    {
        StartCoroutine(RandomSpwaner());
    }

    private void EnemyCreate()
    {
        int value = 0;
        int RandomValue = Random.Range(0, 100);
        float newX = Random.Range(-2f, 2f), newY = Random.Range(7f, 9f);
        if(RandomValue <= 60)
        {
            value = 0;
        }else if(RandomValue <= 90)
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
            yield return new WaitForSeconds(Random.Range(1.7f,2f));
            
        }
    }
}
