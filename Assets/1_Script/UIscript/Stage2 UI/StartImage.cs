using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartImage : MonoBehaviour
{

    private void Awake()
    {
        StartCoroutine(StartScence());
    }
    private IEnumerator StartScence()
    {
        yield return new WaitForSeconds(1);
        GameObject.Find("ship2").transform.position = new Vector3(0, -3.5f, 0);
        Destroy(gameObject);
    }
}
