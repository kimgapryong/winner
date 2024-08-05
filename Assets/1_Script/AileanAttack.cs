using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AileanAttack : MonoBehaviour
{
    private Stage2UiManager uiManager;
    private GameObject gas2;
    private void Start()
    {
        uiManager = GameObject.Find("Stage2Ui").GetComponent<Stage2UiManager>();
        gas2 = uiManager.Attack4;
       
    }
    public IEnumerator Attack1()
    {
        for(int i = 0; i< 3; i++)
        {
            uiManager.bullet.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            uiManager.bullet.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.4f);
        }
        gas2.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        gas2.gameObject.SetActive(false);
    }

    public IEnumerator Attack2()
    {
        for (int i = 0; i < 3; i++)
        {
            uiManager.body.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            uiManager.body.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.4f);
        }
        yield return new WaitForSeconds(2f);

        while (true)
        {
            transform.Translate(Vector2.down * 90 * Time.deltaTime);
            yield return null;
            if(transform.position.y <= -56)
            {
                transform.position = new Vector3(0.2f, 10, 0);
                break;
            }
        }
    }

    public IEnumerator Attack3()
    {
        GameObject Bar = GameObject.Find("BarAttack");
        Transform BarTrabs = Bar.transform;
        foreach(Transform t in BarTrabs)
        {
            t.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.6f);
        }
        yield return new WaitForSeconds(1f);
        foreach (Transform t in BarTrabs)
        {
            t.gameObject.SetActive(false);
        }
    }
}
