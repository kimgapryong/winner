using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Stage2Enemy : MonoBehaviour
{

    private void Start()
    {
        StartCoroutine(Enemy4Create());
    }
    private IEnumerator Enemy4Create()
    {
        while (true)
        {
            int randInt = Random.Range(0, 10);
            if(randInt >= 7)
            {
                for(int i = 0; i< 3; i++)
                {
                    Instantiate(GameManager.Instance.enemy.enemyDatas[3].enemyobj, transform.position, Quaternion.Euler(0, 0, 45));
                }
                
            }
            yield return new WaitForSeconds(1);
        }
    }
}
