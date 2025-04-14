using System.Collections;
using UnityEngine;

public class HomingMissile : MonoBehaviour
{
    public GameObject missilePrefab; // �̻��� ������
    public Transform firePoint; // �̻��� �߻� ��ġ
    public float missileSpeed = 5f;
    public float curveIntensity = 2f; // �־��� ����

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(FireMissiles());
        }
    }

    private IEnumerator FireMissiles()
    {
        for (int i = 0; i < 20; i++) // 5�� ���� �߻�
        {
            GameObject missile = Instantiate(missilePrefab, firePoint.position, Quaternion.identity);

            StartCoroutine(MoveMissile(missile));
            yield return new WaitForSeconds(0.1f); // 0.2�� ����
        }
    }

    private IEnumerator MoveMissile(GameObject missile)
    {
        Vector3 start = missile.transform.position;
        Vector3 end = start + new Vector3(Random.Range(-3.5f, 3.5f), Random.Range(8f, 10f), 0); // ���� ���� ��ġ (�÷��̾�� ����)

        // �߰� � ������ (�־��� ����)
        Vector3 control = (start + end) / 2 + new Vector3(Random.Range(-curveIntensity, curveIntensity), Random.Range(1f, 5f), 0);

        float time = 0;
        while (time < 1)
        {
            time += Time.deltaTime * missileSpeed;
            missile.transform.position = BezierCurve(start, control, end, time);
            yield return null;
        }

        Destroy(missile, 1f); // �̻����� ���� �� ����
    }

    private Vector3 BezierCurve(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        // 2�� ������ � ���� ����
        return (1 - t) * (1 - t) * a + 2 * (1 - t) * t * b + t * t * c;
    }
}