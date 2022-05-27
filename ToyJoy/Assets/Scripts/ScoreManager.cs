using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text score;
    public Text lastScoreUI;
    public GameObject[] starPanels;

    private void Start()
    {
        if (PlayerPrefs.GetInt("Stage") == 1)
        {
            GetStarCount(1, PlayerPrefs.GetInt("Stage1Score"));
            score.text = PlayerPrefs.GetInt("Stage1Score").ToString();

            if (PlayerPrefs.GetInt("Stage1lastScore") <= PlayerPrefs.GetInt("Stage1Score"))
            {
                PlayerPrefs.SetInt("Stage1lastScore", PlayerPrefs.GetInt("Stage1Score"));
            }

            lastScoreUI.text = "High Score:" + PlayerPrefs.GetInt("Stage1lastScore") + "";
        }
        else if(PlayerPrefs.GetInt("Stage") == 2)
        {
            GetStarCount(2, PlayerPrefs.GetInt("Stage2Score"));
            score.text = PlayerPrefs.GetInt("Stage2Score").ToString();
            
            if (PlayerPrefs.GetInt("Stage2lastScore") <= PlayerPrefs.GetInt("Stage2Score"))
            {
                PlayerPrefs.SetInt("Stage2lastScore", PlayerPrefs.GetInt("Stage2Score"));
            }
            lastScoreUI.text = "High Score:" + PlayerPrefs.GetInt("Stage2lastScore") + "";
        }
        else
        {
            GetStarCount(3, PlayerPrefs.GetInt("Stage3Score"));
            score.text = PlayerPrefs.GetInt("Stage3Score").ToString();
            

            if (PlayerPrefs.GetInt("Stage3lastScore") <= PlayerPrefs.GetInt("Stage3Score"))
            {
                PlayerPrefs.SetInt("Stage3lastScore", PlayerPrefs.GetInt("Stage3Score"));
            }
            lastScoreUI.text = "High Score:" + PlayerPrefs.GetInt("Stage3lastScore") + "";
        }
        
    }

    public void ReturnToMain()
    {
        SceneManager.LoadScene("Launcher");
    }

    public void GetStarCount(int stage, int num)
    {
        if (stage == 1)
        {
            if (num >= 44)
            {
                starPanels[0].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 88)
            {
                starPanels[1].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 132)
            {
                starPanels[2].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 176)
            {
                starPanels[3].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 220)
            {
                starPanels[4].GetComponent<Image>().color = Color.yellow;
            }

        }
        else if (stage == 2)
        {
            if (num >= 64)
            {
                starPanels[0].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 128)
            {
                starPanels[1].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 192)
            {
                starPanels[2].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 256)
            {
                starPanels[3].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 320)
            {
                starPanels[4].GetComponent<Image>().color = Color.yellow;
            }
        }
        else
        {
            if (num >= 80)
            {
                starPanels[0].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 160)
            {
                starPanels[1].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 240)
            {
                starPanels[2].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 320)
            {
                starPanels[3].GetComponent<Image>().color = Color.yellow;
            }
            if (num >= 400)
            {
                starPanels[4].GetComponent<Image>().color = Color.yellow;
            }
        }

    }
}
