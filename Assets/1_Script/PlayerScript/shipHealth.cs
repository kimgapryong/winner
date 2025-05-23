using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipHealth : MonoBehaviour
{
    public int health = 3;

    private bool isAttack = true;
    private Renderer objrenderer;
    private Animator animator;
    public AnimationClip deathClip;

    private UIManager manager;

    public event EventHandler shipDie;
    private void Start()
    {
        manager = GameObject.Find("UiManager").GetComponent<UIManager>();
        objrenderer = GetComponent<Renderer>();    
        animator = GetComponent<Animator>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(HomingMissile.valier == true)
            return;

        if (collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            if(isAttack)
            {
                isAttack = false;
                if(health > 0)
                {
                    health--;
                    manager.health = health;
                    StartCoroutine(IsAttackSecond());
                }
                else
                {
                    animator.SetBool("isDeath", true);
                    manager.health = 0;
                    GameManager.Instance.Ranking.AddScores(GameManager.Instance.uiManager.score);
                    StartCoroutine(WaitForAnimationToFinish());
                    shipDie?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (HomingMissile.valier == true)
            return;

        if (collision.CompareTag("Boss"))
        {
            if (isAttack)
            {
                isAttack = false;
                if (health > 0)
                {
                    health--;
                    manager.health = health;
                    StartCoroutine(IsAttackSecond());
                }
                else
                {
                    animator.SetBool("isDeath", true);
                    manager.health = 0;
                    GameManager.Instance.Ranking.AddScores(GameManager.Instance.uiManager.score);
                    StartCoroutine(WaitForAnimationToFinish());
                    shipDie?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }

    private IEnumerator IsAttackSecond()
    {
        for(int i = 0; i < 5; i++)
        {
            objrenderer.enabled = false;
            yield return new WaitForSeconds(0.2f);
            objrenderer.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
        
        isAttack = true;
        
    }

    public IEnumerator WaitForAnimationToFinish()
    {
        
        yield return new WaitForSeconds(deathClip.length);
        Destroy(gameObject);
    }
}
