using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class AileanRandom : MonoBehaviour
{
    private AileanAttack AileanAttack;
    private void Start()
    {
        AileanAttack = GetComponent<AileanAttack>();
        StartCoroutine(Aileans());
    }
    private IEnumerator Aileans()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.8f);
            int RandVlaue = Random.Range(0, 3);
            switch (RandVlaue)
            {
                case 0:
                    StartCoroutine(AileanAttack.Attack1()); 
                    break;
                case 1:
                    StartCoroutine (AileanAttack.Attack2());
                    break;
                case 2:
                    StartCoroutine(AileanAttack.Attack3());
                    break;

            }
            yield return new WaitForSeconds(2);
        }
        
    }
}
