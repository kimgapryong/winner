using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoGame : MonoBehaviour
{
    public GameObject panel;
    public void GoGames()
    {
        SceneManager.LoadScene("Stage1");
    }
    public void CanSee()
    {
        panel.gameObject.SetActive(true);       
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
