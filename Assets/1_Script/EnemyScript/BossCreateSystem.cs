using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BossCreateSystem : MonoBehaviour
{

    //BossData
    private BossCheckClass.Boss BossType;
    private Enemy.bossData bossData;

    private GameObject enemycreate;
    private GameObject oilBar;
    //GameManager 이용

    private UIManager manager;
    private Enemy Enemy;

    private bool isBossImageSpwanStarted = false;
    [SerializeField]
    private Image BossTxt;
    private void Start()
    {
        enemycreate = GameObject.Find("enemyCreate");
        oilBar = GameObject.Find("oilBar");
        manager = GameManager.Instance.uiManager;
        Enemy = GameManager.Instance.enemy;
        
    }

    private void Update()
    {
        CheckScore();
    }

    private void CheckScore()
    {
        if(manager.score >= 10 && !isBossImageSpwanStarted)
        {
            //나중에 다시 활성화 시켜야 할 것
            enemycreate.SetActive(false);
            oilBar.SetActive(false);

            manager.bossHealth.gameObject.SetActive(true);
            StartCoroutine(BossImageSpwan());
            isBossImageSpwanStarted = true;

            //보스의 데이터 넘겨주기
            BossType = BossCheckClass.Boss.Boss1;
            bossData = Enemy.SetBossData(BossType);

        
        }
    }

    private IEnumerator BossImageSpwan()
    {
        for (int i = 0; i < 3; i++)
        {
            BossTxt.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
            BossTxt.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.6f);
        }
        Instantiate(bossData.bossobj, new Vector3(0, 3.5f, 0), Quaternion.identity);
    }
}
public class BossCheckClass
{
    public enum Boss
    {
        Boss1,
        Boss2
    }

}
