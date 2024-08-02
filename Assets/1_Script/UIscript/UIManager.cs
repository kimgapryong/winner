using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private shipHealth shipHealth;
    public int health;
  
    public int score = 0;
    [SerializeField]
    private GameObject over;

    [SerializeField]
    public Text scoreTxt;

    [SerializeField]
    public Text healthTxt;

    [SerializeField]
    private Text ItemTxt;

    public Image BossBody;
    public GameObject BossRuncher;

    //보스 체력바
    public Slider bossHealth;

    public HealthBar slider;

    private void Start()
    {
        shipHealth = FindObjectOfType<shipHealth>();
        slider = FindObjectOfType<HealthBar>();
        
        health = shipHealth.health;

        shipHealth.shipDie += ReStart;
        slider.oilDie += ReStart;

        Debug.Log(health);
    }

    private void ReStart(object sender, EventArgs e)
    {
        
        over.SetActive(true);
        
    }

    private void Update()
    {
        scoreTxt.text = String.Format("Score: {0:n0}", score);
        healthTxt.text = $"생명: {health}";
        ItemTxt.text = $"아이템: {GameManager.Instance.attack.runcherValue}";
    }

    
}
