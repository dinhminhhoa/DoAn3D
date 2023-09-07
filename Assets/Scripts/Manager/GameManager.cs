using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : BaseManager<GameManager>
{
   
    private bool isPlaying = false;
    public bool IsPlaying => isPlaying;

   

    public void StartGame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        if (isPlaying)
        {
            isPlaying = false;
            Time.timeScale = 0f;
        }
    }

    public void ResumeGame()
    {
        isPlaying = true;
        Time.timeScale = 1f;
    }

    public void RestarGame()
    { 
        ChangeScene("Loading");

        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveVictoryPanel(false);
            UIManager.Instance.ActiveGamePanel(false);
            UIManager.Instance.ActiveLosePanel(false);
            UIManager.Instance.ActiveMenuPanel(true);
           
        }
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        Debug.Log(" hien lose");
        EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
