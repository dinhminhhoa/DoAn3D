using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish_Checkpoint : MonoBehaviour
{

    private bool levelComplete = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !levelComplete)
        {
            if (AudioManager.HasInstance)
            {
             //   AudioManager.Instance.PlaySE(AUDIO.SE_PLAYER_FINISH);
            }
            levelComplete = true;
            Invoke("CompleteLevel", 2f);// 2 giay sau chuyen scene
        }
    }
    private void CompleteLevel()
    {
        if (SceneManager.GetActiveScene().name.Equals("LevelBosss"))
        {
            if (UIManager.HasInstance)
            {
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
