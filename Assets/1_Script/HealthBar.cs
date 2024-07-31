using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    public Slider healthSlider;

    private void Start()
    {
        StartCoroutine(Hpdown());
    }
    private IEnumerator Hpdown()
    {
        while (true)
        {
            healthSlider.value -= 0.001f;
            yield return new WaitForSeconds(0.1f);
        }
        
    }
}
