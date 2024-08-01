using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyDieItem : MonoBehaviour
{
    private Itemsobjects Itemsobjects;
    private EnemyDestroy EnemyDestroy;

    private void Start()
    {
        Itemsobjects = FindObjectOfType<Itemsobjects>();
        EnemyDestroy = GetComponent<EnemyDestroy>();
    }

    public void ItemCreate()
    {
        int randomValue = Random.Range(0,100);
        int value = 0;
        if(randomValue <= 35)
        {
            value = 0;
        }else if(randomValue <= 38)
        {
            value= 1;
        }else if(randomValue <= 40)
        {
            value = 2;
        }else if(randomValue <= 45)
        {
            value = 3;
        }
        else
        {
            value = Itemsobjects.gameItems.Length + 1;
        }
        if(value != Itemsobjects.gameItems.Length + 1)
        {
            Instantiate(Itemsobjects.gameItems[value].item, transform.position, Quaternion.identity);
        }
        
    }

    
}
