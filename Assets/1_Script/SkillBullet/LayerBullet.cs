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

                    // ���� ���� ������ ����
                    Vector3 originalScale = transform.localScale;
                    float originalWidth = originalScale.x;
                    float targetWidth = 15f;

                    float deltaWidth = targetWidth - originalWidth;

                    // ������ �������θ� �þ�� ���� (�߽��� �������� �̵�)
                    transform.localPosition += new Vector3(0, deltaWidth * 0.35f, 0f);

                    // ������ ����
                    transform.localScale = new Vector3(targetWidth, 5f, 1f);
                }
   
                break;
            case Define.States.Idle:
                {
                    animator.Play("Layer_Idle");
                    Debug.Log("���ܰ�");
                    StartCoroutine(StartAtk(0.54f));
                }
             
                break;
        }
    }

    private IEnumerator StartAtk(float animTime)
    {
        Debug.Log("���۵�");
        yield return new WaitForSeconds(animTime);
        State = Define.States.Attack;
        Debug.Log(time);
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        
    }
}
