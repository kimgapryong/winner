using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveEnemy4 : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    private Vector3 target;

    private void Start()
    {
        StartCoroutine(CreateBullet());
        target = new Vector3(0, -3.5f);
    }


    private IEnumerator CreateBullet()
    {
        while (true)
        {
            Vector2 newPos = target - transform.position;
            float rotZ = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
            Instantiate(bullet, transform.position, Quaternion.Euler(0,0, rotZ - 90));
            yield return new WaitForSeconds(1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * 3 * Time.deltaTime);
        if(transform.position.x <= -5)
        {
            Destroy(gameObject);
        }
    }
}
