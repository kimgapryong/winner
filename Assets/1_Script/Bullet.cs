using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float Speed = 15f;

    



    private void Update()
    {
        BulletAttack();
    }
    private void BulletAttack()
    {
       
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        if(transform.position.y > 6f)
        {
            Destroy(transform.gameObject);
        }
    }

    


}
