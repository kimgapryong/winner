using UnityEngine;
using UnityEngine.SceneManagement;

public class RePlayButton : MonoBehaviour
{
    public void RestartScene()
    {
        
        SceneManager.LoadScene("Stage1");
    }
}