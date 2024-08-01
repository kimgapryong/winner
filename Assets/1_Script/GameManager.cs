using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UIManager uiManager;
    public Attack attack;

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
    }

    private void InitializeReferences()
    {
        GameObject ship2 = GameObject.Find("ship2");
        if (ship2 != null)
        {
           uiManager = GameObject.Find("UiManager").GetComponent<UIManager>();
            attack = ship2.GetComponentInChildren<Attack>();
            if (uiManager == null)
            {
                Debug.LogError("shipHealth component not found on ship2.");
            }
            if (attack == null)
            {
                Debug.LogError("Attack component not found in children of ship2.");
            }
        }
        else
        {
            Debug.LogError("ship2 GameObject not found.");
        }
    }
}
