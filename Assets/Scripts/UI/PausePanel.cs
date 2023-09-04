using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{
    public void OnClickedResumeButton()
    {
        if (GameManager.HasInstance && UIManager.HasInstance)
        {
         
            GameManager.Instance.ResumeGame();

            UIManager.Instance.ActivePausePanel(false);
         
        }
    }

    public void OnClickedSettingButton()
    {
        if (UIManager.HasInstance)
        {
            UIManager.Instance.ActiveSettingPanel(true);
            UIManager.Instance.ActivePausePanel(false);
        }
    }

    public void OnClickedQuitToMenuButton()
    {
        if (GameManager.HasInstance)
        {
            GameManager.Instance.ChangeScene("Loading");
            UIManager.Instance.ActivePausePanel(false);
            UIManager.Instance.ActiveGamePanel(false);
            UIManager.Instance.ActiveMenuPanel(true);
        }
    }
}
