using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerBullet : MonoBehaviour
{
    public Animator animator;
    public Collider2D coll;
    private float time = 5f;

    private Define.States _state;
    public Define.States State
    {
        get { return _state; }
        set
        {
            _state = value;

            if(coll != null )
            {
                if(value == Define.States.Idle)
                    coll.enabled = false;
                else
                    coll.enabled = true;
            }

            if(animator != null)
                ChangeAnim(value);
        }
    }
    public void StartInit(float time)
    {
        this.time = time;

        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        
        coll.enabled = false;

        
        State = Define.States.Idle;
    }

    private void ChangeAnim(Define.States state)
    {
        switch (state)
        {
            case Define.States.Attack:
                {
                    animator.Play("Layer_Atk");
                    coll.enabled = true;

                    // 현재 로컬 스케일 기준
                    Vector3 originalScale = transform.localScale;
                    float originalWidth = originalScale.x;
                    float targetWidth = 15f;

                    float deltaWidth = targetWidth - originalWidth;

                    // 오른쪽 방향으로만 늘어나게 보정 (중심이 왼쪽으로 이동)
                    transform.localPosition += new Vector3(0, deltaWidth * 0.35f, 0f);

                    // 스케일 조정
                    transform.localScale = new Vector3(targetWidth, 5f, 1f);
                }
   
                break;
            case Define.States.Idle:
                {
                    animator.Play("Layer_Idle");
                    Debug.Log("전단계");
                    StartCoroutine(StartAtk(0.54f));
                }
             
                break;
        }
    }

    private IEnumerator StartAtk(float animTime)
    {
        Debug.Log("시작됨");
        yield return new WaitForSeconds(animTime);
        State = Define.States.Attack;
        Debug.Log(time);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}
