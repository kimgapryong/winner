using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy3Attack : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    private GameObject target;

    private void Start()
    {
        target = GameObject.Find("ship2");
        StartCoroutine(StartBullet());
    }

   

    private void RoateBullet()
    {
        Vector2 newPos = target.transform.position - transform.position;
        float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rotZ + 90));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rotZ + 120));
        Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, rotZ + 60));

    }

    private IEnumerator StartBullet()
    {
        while (true)
        {
            RoateBullet();
            yield return new WaitForSeconds(1);
        }
       
    }
}
