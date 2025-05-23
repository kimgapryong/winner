using System.Collections;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public GameObject particel; // 전체 광역기;
    

    public GameObject missilePrefab; // 미사일 프리팹
    public Transform firePoint; // 미사일 발사 위치
    public float missileSpeed = 5f;
    public float curveIntensity = 2f; // 휘어짐 강도

    //-----
    //3번째 스킬
    public GameObject bullet;
    private bool isAtk;
    private float time = 5;

    //4번째 베리어 스킬
    public static bool valier;
    private float valierTime = 3f;
    public GameObject ValierObj;
    private Coroutine valierCor;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(FireMissiles());
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            ParticelAttack();
        }
        if(Input.GetKeyDown(KeyCode.R))
        {
            StartAtkBullet();
        }
        if(Input.GetKeyDown(KeyCode.T))
        {
            StartVarier();
        }
    }
    private void StartVarier()
    {
        if (valierCor != null)
            return;

        GameObject clone = Instantiate(ValierObj, transform);
        clone.transform.localPosition = Vector3.zero;

        valierCor = StartCoroutine(EnumerValier(clone));
    }
    private IEnumerator EnumerValier(GameObject clone)
    {
        valier = true;
        yield return new WaitForSeconds(valierTime);
        Destroy(clone);
        valier = false;
        valierCor = null;
    }
    private void StartAtkBullet()
    {
        if(isAtk) 
            return; 

        GameObject clone = Instantiate(bullet, transform.Find("ship2-flame"));
        clone.transform.eulerAngles = new Vector3(0, 0, 90);
        clone.transform.localPosition = new Vector3(0, 0.5f, 0);
        clone.AddLayer(time);
        StartCoroutine(AtkBulletCool());
    }
    private IEnumerator AtkBulletCool()
    {
        isAtk = true;
        yield return new WaitForSeconds(time);
        isAtk = false;
    }

    private void ParticelAttack()
    {
        GameObject clone = Instantiate(particel,transform.position, Quaternion.identity);
        foreach(var enemy in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            enemy.GetComponent<EnemyDieItem>().ItemCreate();
            Destroy(enemy);
        }
        Destroy(clone , 2);
    }
        


    


    //파라 궁극기
    private IEnumerator FireMissiles()
    {
        for (int i = 0; i < 20; i++) // 5발 연속 발사
        {
            GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);

            StartCoroutine(MoveMissile(missile));
            yield return new WaitForSeconds(0.1f); // 0.2초 간격
        }
    }

    private IEnumerator MoveMissile(GameObject missile)
    {
        Vector3 start = missile.transform.position;
        Vector3 end = start + new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(8f, 10f), 0); // 최종 도착 위치 (플레이어보다 위쪽)

        // 중간 곡선 제어점 (휘어짐 조절)
        Vector3 control = (start + end) / 2 + new Vector3(Random.Range(-curveIntensity, curveIntensity), Random.Range(1f, 5f), 0);

        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * missileSpeed;
            if(missile != null)
                missile.transform.position = BezierCurve(start, control, end, time);
            yield return null;
        }

        Destroy(missile, 1f); // 미사일이 도착 후 삭제
    }

    private Vector3 BezierCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        // 2차 베지어 곡선 공식 적용
        return (1 - t) * (1 - t) * a + 2 * (1 - t) * t * b + t * t * c;
    }
}