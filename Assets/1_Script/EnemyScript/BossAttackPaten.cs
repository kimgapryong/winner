using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPaten : MonoBehaviour
{
    [SerializeField]
    private GameObject BossBullet;
    [SerializeField]
    private GameObject BossRuncher;

    private UIManager uIManager;
    private BossRandomPaten randomPaten;
    

    private void Start()
    {
        uIManager = GameManager.Instance.uiManager;
        randomPaten = GetComponent<BossRandomPaten>();
    }

    private void Update()
    {
        if(transform.gameObject == null)
        {
            uIManager.BossRuncher.gameObject.SetActive(false);
            uIManager.BossBody.gameObject.SetActive(false);
        }
    }

    public IEnumerator BossRuncherAttack()
    {
        
            for (int i = 0; i < 3; i++)
            {
                uIManager.BossRuncher.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                uIManager.BossRuncher.SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }
            uIManager.BossRuncher.SetActive(false);
            yield return new WaitForSeconds(0.5f);

            Instantiate(BossRuncher, new Vector3(2, transform.position.y, 0), Quaternion.identity);
            Instantiate(BossRuncher, new Vector3(-2, transform.position.y, 0), Quaternion.identity);
        
       
       
        
        
    }
    public IEnumerator Bossbodytor()
    {
      
            for (int i = 0; i < 3; i++)
            {
                uIManager.BossBody.gameObject.SetActive(false);
                yield return new WaitForSeconds(0.3f);
                uIManager.BossBody.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.3f);
            }
            uIManager.BossBody.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.7f);
            randomPaten.isMove = true;
        
     

    }

    public IEnumerator BossBulletator()
    {
        for (int i = 0; i < 2; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * 10));
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * -15));
                yield return new WaitForSeconds(0.4f);
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * 15));
                Instantiate(BossBullet, transform.position, Quaternion.Euler(0, 0, j * -10));
                yield return new WaitForSeconds(0.4f);
            }
           
        }
        
    }
}
