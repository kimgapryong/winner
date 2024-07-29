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
        public int health;
        public float speed;

    }
    [SerializeField]private enemyData[] enemyDatas;

    private void Start()
    {
        StartCoroutine(RandomSpwaner());
    }


    private void EnemyCreate()
    {
        int RandomValue = Random.Range(0, enemyDatas.Length);
        float newX = Random.Range(-2f, 2f), newY = Random.Range(7f, 9f);
        GameObject clone = Instantiate(enemyDatas[RandomValue].enemyobj, new Vector3(newX, newY), Quaternion.identity);
        if(clone != null )
        {
            Rigidbody2D rigid = clone.AddComponent<Rigidbody2D>();
            CircleCollider2D collider =  clone.AddComponent<CircleCollider2D>();
            collider.isTrigger = true;
            rigid.gravityScale = 0;
            rigid.constraints = (RigidbodyConstraints2D)RigidbodyConstraints.FreezeRotationZ;
            clone.AddComponent<EnemyDestroy>();
            
            if(clone.transform.position.y >= -5)
            {
                rigid.velocity = new Vector2(0, -enemyDatas[RandomValue].speed);
            }
            
        }
    } 
    

    
    private IEnumerator RandomSpwaner()
    {
        while(true)
        {
            EnemyCreate();
            yield return new WaitForSeconds(Random.Range(1f,1.5f));
            
        }
    }
}
