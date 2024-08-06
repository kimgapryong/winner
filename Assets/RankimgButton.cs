using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankimgButton : MonoBehaviour
{
    public void LookRanking()
    {
        GameManager.Instance.Ranking.gameObject.SetActive(true);
    }
}
