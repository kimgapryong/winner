using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRuncherSpeed : MonoBehaviour
{
    

    private void Start()
    {
    }
    void Update()
    {
        transform.Translate(Vector2.down * 6 * Time.deltaTime);
        if(transform.position.y <= -5)
        {
            Destroy(gameObject);
           
        }
    }
}
