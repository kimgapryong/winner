using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newStageBullet : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 8 * Time.deltaTime);   
        if(transform.position.y <= -5 || transform.position.x <= -5)
        {
            Destroy(gameObject);
        }
    }
}
