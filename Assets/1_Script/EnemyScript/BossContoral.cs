using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossContoral : MonoBehaviour
{
    public CircleBoss CircleBoss;
    public event EventHandler BossDie;
    public bool isDie = false;
    
    void Update()
    {
       
        if (isDie && !GameManager.Instance.isNext)
        {

            
            Debug.Log("아이스크림");
            BossDie?.Invoke(this, EventArgs.Empty);
            GameManager.Instance.isNext = true;
        } 
    }
}
