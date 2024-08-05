using UnityEngine;
using UnityEngine.SceneManagement;

public class RePlayButton : MonoBehaviour
{
    public void RestartScene()
    {
        GameManager.Instance.uiManager.over.SetActive(false);
        Destroy(GameManager.Instance.uiManager.gameObject);
        Destroy(GameManager.Instance.gameObject);
        SceneManager.LoadScene("Stage1");
        
        
        
    }
}