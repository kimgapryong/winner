using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject runcher;


    public int runcherValue = 0;

    public int AttackCount = 0;
    private int UpgradeValue = 4;
    private const float BulletSpacing = 0.2f;
    private void Start()
    {

        StartCoroutine(BullectAttack());

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(runcherValue > 0)
            {
                Instantiate(runcher, transform.position + Vector3.up * 0.3f, Quaternion.identity);
                runcherValue--;
            }
        } 
    }
    private IEnumerator BullectAttack()
    {
        while (true)
        {
            ShootBullets();
             yield return new WaitForSeconds(0.3f);
        }

    }

    private void ShootBullets()
    {
        Vector3 basePosition = transform.position;
        List<Vector3> offsets = new List<Vector3>();

        if (AttackCount <= UpgradeValue)
        {
           
            for (int i = 0; i <= AttackCount; i++)
            {
                if (i == 0)
                {
                    offsets.Add(Vector3.zero);
                }
                else
                {
                    offsets.Add(Vector3.right * i * BulletSpacing);
                    offsets.Add(Vector3.left * i * BulletSpacing);
                }
            }

           
            foreach (var offset in offsets)
            {
                Instantiate(bullet, basePosition + offset, Quaternion.Euler(0, 0, 90));
            }
        }
        else
        {
            AttackCount = UpgradeValue;
        }
    }
}
