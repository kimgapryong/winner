using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * 7f * Time.deltaTime);
    }
}
