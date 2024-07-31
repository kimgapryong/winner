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
        if(randomValue < 50)
        {
            value = 0;
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
