using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;

    private void Start()
    {
        StartCoroutine(BullectAttack());
    }
    private IEnumerator BullectAttack()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(0,0,90));
            yield return new WaitForSeconds(0.8f);
        }
       
    }
}
