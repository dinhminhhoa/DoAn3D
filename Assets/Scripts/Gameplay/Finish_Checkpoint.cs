using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Checkpoint : MonoBehaviour
{

    private bool levelComplete = false;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelComplete)
        {
            if (AudioManager.HasInstance)
            {
             //   AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_FINISH);
            }
            levelComplete = true;
            Invoke("CompleteLevel", 0f);// 2 giay sau chuyen scene
        }
    }
    private void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().name.Equals("1"))
        {
            if (UIManager.HasInstance)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0f;
                UIManager.Instance.ActiveVictoryPanel(true);
                return;
            }
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //if (UIManager.HasInstance && AudioManager.HasInstance)
        //{

        //   // AudioManager.Instance.PlayBGM(AUDIO.BGM_BGM_03);
        //}
        //UIManager.Instance.GamePanel.SetTimeRemain(240);

    }
}
