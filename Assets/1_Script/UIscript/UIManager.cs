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
    private Text scoreTxt;

    [SerializeField]
    private Text healthTxt;

    [SerializeField]
    private Text ItemTxt;

    private HealthBar slider;

    private void Start()
    {
        shipHealth = FindObjectOfType<shipHealth>();
        slider = FindObjectOfType<HealthBar>();
        health = shipHealth.health;
        shipHealth.shipDie += ReStart;
        
        slider.oilDie += ReStart;
    }

    private void ReStart(object sender, EventArgs e)
    {
        
        over.SetActive(true);
        
    }

    private void Update()
    {
        scoreTxt.text = String.Format("Score: {0:n0}", score);
        healthTxt.text = $"���: {health}";
        ItemTxt.text = $"������: {GameManager.Instance.attack.runcherValue}";
    }

    
}