using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public Text lastScoreUI;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Stage") == 1)
        {
            score.text = PlayerPrefs.GetInt("Stage1Score").ToString();
            lastScoreUI.text = "High Score:" + PlayerPrefs.GetInt("Stage1lastScore") + "";

            if (PlayerPrefs.GetInt("Stage1lastScore") < PlayerPrefs.GetInt("Stage1Score"))
            {
                PlayerPrefs.SetInt("Stage1lastScore", PlayerPrefs.GetInt("Stage1Score"));
            }
        }else if(PlayerPrefs.GetInt("Stage") == 2)
        {
            score.text = PlayerPrefs.GetInt("Stage2Score").ToString();
            lastScoreUI.text = "High Score:" + PlayerPrefs.GetInt("Stage2lastScore") + "";

            if (PlayerPrefs.GetInt("Stage2lastScore") < PlayerPrefs.GetInt("Stage2Score"))
            {
                PlayerPrefs.SetInt("Stage2lastScore", PlayerPrefs.GetInt("Stage2Score"));
            }
        }
        else
        {
            score.text = PlayerPrefs.GetInt("Stage3Score").ToString();
            lastScoreUI.text = "High Score:" + PlayerPrefs.GetInt("Stage3lastScore") + "";

            if (PlayerPrefs.GetInt("Stage3lastScore") < PlayerPrefs.GetInt("Stage3Score"))
            {
                PlayerPrefs.SetInt("Stage3lastScore", PlayerPrefs.GetInt("Stage3Score"));
            }
        }
        
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Launcher");
    }
}
