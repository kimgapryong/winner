using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UIManager uiManager;
    public Attack attack;
    public Enemy enemy;
    public GameObject ship2;
    public bool isNext = false;
    public BossContoral bossContoral;
    public bool GameStage = false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeReferences();
    }

    private void Start()
    {
        InitializeReferences();
        if(bossContoral != null)
        {
            Debug.Log("됐다");
            bossContoral.BossDie += StartBossDie;
        }
        else
        {
            Debug.Log("문제 발생");
        }
        
    }

    public void StartBossDie(object sender, EventArgs e)
    {
            StartCoroutine(LoadNextStage());
    }

    private void InitializeReferences()
    {
        ship2 = GameObject.Find("ship2");

        if (ship2 != null)
        {
            bossContoral = GameObject.Find("BossCreate").GetComponent<BossContoral>();
           uiManager = GameObject.Find("UiManager").GetComponent<UIManager>();
            DontDestroyOnLoad (uiManager.gameObject);

            attack = ship2.GetComponentInChildren<Attack>();

            enemy = GameObject.Find("enemyCreate").GetComponent<Enemy>();
            
            if (uiManager == null)
            {
                Debug.LogError("shipHealth component not found on ship2.");
            }
            if (attack == null)
            {
                Debug.LogError("Attack component not found in children of ship2.");
            }
            if(enemy == null)
            {
                Debug.LogError("Enemy component not found in children of ship2.");
            }
        }
        else
        {
            Debug.LogError("ship2 GameObject not found.");
        }
    }


    public IEnumerator LoadNextStage()
    {
        yield return new WaitForSeconds(3);
        
        while (ship2.transform.position.y <= 4.5f)
        {
            ship2.transform.Translate(Vector2.up * 5f * Time.deltaTime);
            yield return null;
        }
        enemy.gameObject.SetActive(true);   
        Destroy(uiManager.BossBody);
        Destroy(uiManager.BossRuncher);
        uiManager.bossHealth.gameObject.SetActive(false);
        GameStage = true;
        SceneManager.LoadScene("Stage2");
    }
}
