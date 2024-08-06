using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    private Transform RankContainer;
    private Transform RankMessage;
    private List<Transform> RankList;

    private void Start()
    {
        RankContainer = transform.Find("RankContainer");
        RankMessage = RankContainer.Find("Rankmessage");

        RankMessage.gameObject.SetActive(false);

        string jsonString = PlayerPrefs.GetString("hightTable");
        SethightScore highscores = JsonUtility.FromJson<SethightScore>(jsonString);

        if (highscores == null)
        {
            AddScores(10);
            jsonString = PlayerPrefs.GetString("hightTable");
            highscores = JsonUtility.FromJson<SethightScore>(jsonString);
        }

      
        AddScores(13);

        // Sort the high scores list
        highscores.HigthScoreList.Sort((x, y) => y.score.CompareTo(x.score));

        // Keep only the top 10 scores
        if (highscores.HigthScoreList.Count > 10)
        {
            highscores.HigthScoreList = highscores.HigthScoreList.GetRange(0, 10);
        }

        // Update the stored scores with the top 10 list
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("hightTable", json);
        PlayerPrefs.Save();

        RankList = new List<Transform>();
        foreach (HightScore score in highscores.HigthScoreList)
        {
            SetHightScore(score, RankContainer, RankList);
        }
    }

    private void SetHightScore(HightScore hightscore, Transform container, List<Transform> list)
    {
        int hight = 40;

        Transform newRankMessage = Instantiate(RankMessage, container);
        RectTransform mesRect = newRankMessage.GetComponent<RectTransform>();
        mesRect.anchoredPosition = new Vector2(0, -hight * list.Count);
        newRankMessage.gameObject.SetActive(true);

        int Rank = list.Count + 1;
        string RankString;
        switch (Rank)
        {
            case 1: RankString = "1ST"; break;
            case 2: RankString = "2ND"; break;
            case 3: RankString = "3RD"; break;
            default: RankString = Rank + "TH"; break;
        }

        newRankMessage.Find("PosTxt").GetComponent<Text>().text = RankString;

        int score = hightscore.score;
        newRankMessage.Find("ScoreTxt").GetComponent<Text>().text = score.ToString();

        list.Add(newRankMessage);
    }

    public void AddScores(int score)
    {
        HightScore hightscore = new HightScore { score = score };

        string jsonString = PlayerPrefs.GetString("hightTable");
        SethightScore highscores = JsonUtility.FromJson<SethightScore>(jsonString);
        if (highscores == null)
        {
            highscores = new SethightScore()
            {
                HigthScoreList = new List<HightScore>()
            };
        }

        highscores.HigthScoreList.Add(hightscore);

        // Sort the high scores list
        highscores.HigthScoreList.Sort((x, y) => y.score.CompareTo(x.score));

        // Keep only the top 10 scores
        if (highscores.HigthScoreList.Count > 10)
        {
            highscores.HigthScoreList = highscores.HigthScoreList.GetRange(0, 10);
        }

        // Update the stored scores with the top 10 list
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("hightTable", json);
        PlayerPrefs.Save();
    }

    private class SethightScore
    {
        public List<HightScore> HigthScoreList;
    }

    [System.Serializable]
    private class HightScore
    {
        public int score;
    }
}
