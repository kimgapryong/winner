using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPaten : MonoBehaviour
{
    [SerializeField]
    private GameObject BossBullet;

    private UIManager uIManager;

    

    private void Start()
    {
        uIManager = GameManager.Instance.uiManager;
    }


    public IEnumerator Bossbodytor()
    {
        for(int i = 0; i < 3; i++)
        {
            uIManager.BossBody.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            uIManager.BossBody.gameObject.SetActive(true);
        }
        uIManager.BossBody.gameObject.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        

    }

    public IEnumerator BossBulletator()
    {
        for (int i = 0; i < 8; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * 10));
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * -15));
                yield return new WaitForSeconds(0.8f);
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * 15));
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * -10));
                yield return new WaitForSeconds(0.8f);
            }
           
        }
    }
}
