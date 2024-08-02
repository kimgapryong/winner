using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBullet : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * 4f * Time.deltaTime);
        if(transform.position.y < -5 || transform.position.y > 5 || transform.position.x > 6 || transform.position.x < -6)
        {
            Destroy(gameObject);
        }
    }
}
