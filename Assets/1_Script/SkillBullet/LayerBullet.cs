using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerBullet : MonoBehaviour
{
    private Animator animator;
    private Collider2D coll;
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

        State = Define.States.Idle;
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        
        coll.enabled = false;
    }

    private void ChangeAnim(Define.States state)
    {
        switch (state)
        {
            case Define.States.Attack:
                    animator.Play("Layer_Idle");
                break;
            case Define.States.Idle:
                {
                    animator.Play("Layer_Idle");
                    transform.localScale = new Vector3(15, 5);
                    AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                    float stateTime = stateInfo.normalizedTime;
                    StartCoroutine(StartAtk(stateTime));
                }
             
                break;
        }
    }

    private IEnumerator StartAtk(float animTime)
    {
        yield return new WaitForSeconds(animTime);
        State = Define.States.Attack;
        yield return new WaitForSeconds(time);
        
    }
}
