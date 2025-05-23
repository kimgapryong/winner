using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider healthSlider;
    public event EventHandler oilDie;

    private void Start()
    {
        
        Transform slidrTrans = GameObject.Find("UiManager").transform.Find("HealthBar");
        healthSlider = slidrTrans.GetComponent<Slider>();
        StartCoroutine(Hpdown());
    }
    private IEnumerator Hpdown()
    {
        while (true)
        {
            if(healthSlider != null && healthSlider.value > 0)
            {
                healthSlider.value -= 0.001f;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                Destroy(GameObject.Find("ship2"));
                oilDie?.Invoke(this, EventArgs.Empty);
                break;
            }
        }
        
    }
}
