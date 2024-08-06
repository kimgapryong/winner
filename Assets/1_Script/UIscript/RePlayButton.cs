using UnityEngine;
using UnityEngine.SceneManagement;

public class RePlayButton : MonoBehaviour
{
    public void RestartScene()
    {
        GameManager.Instance.uiManager.over.SetActive(false);
        Destroy(GameManager.Instance.uiManager.gameObject);
        Destroy(GameManager.Instance.gameObject);
        GameManager.Instance.Ranking.gameObject.SetActive(false);
        SceneManager.LoadScene("Stage1");
        
        
        
    }
}