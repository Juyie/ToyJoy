using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageChoose : MonoBehaviour
{
    public GameObject[] panels;
    public int nowSee;
    public Text lastScoreUIForStage1;
    public Text lastScoreUIForStage2;
    public Text lastScoreUIForStage3;

    public enum ActivePanel
    {
        STAGE1 = 0,
        STAGE2 = 1,
        STAGE3 = 2,
    }

    private void ChangePanel(ActivePanel panel)
    {
        foreach (GameObject _panel in panels)
        {
            Debug.Log(panels);
            _panel.SetActive(false);
        }
        panels[(int)panel].SetActive(true);
    }


    void Start()
    {
        lastScoreUIForStage1.text = "High Score:" + PlayerPrefs.GetInt("Stage1lastScore") + "";
        lastScoreUIForStage2.text = "High Score:" + PlayerPrefs.GetInt("Stage2lastScore") + "";
        lastScoreUIForStage3.text = "High Score:" + PlayerPrefs.GetInt("Stage3lastScore") + "";
        ChangePanel(ActivePanel.STAGE1);
        nowSee = 0;
    }

    public void RightChangeStage()
    {
        if (nowSee == 0)
        {
            ChangePanel(ActivePanel.STAGE2);
            nowSee = 1;
        }
        else if (nowSee == 1)
        {
            ChangePanel(ActivePanel.STAGE3);
            nowSee = 2;
        }
        else
        {
            ChangePanel(ActivePanel.STAGE1);
            nowSee = 0;
        }
    }

    public void LeftChangeStage()
    {
        if (nowSee == 0)
        {
            ChangePanel(ActivePanel.STAGE3);
            nowSee = 2;
        }
        else if (nowSee == 1)
        {
            ChangePanel(ActivePanel.STAGE1);
            nowSee = 0;
        }
        else
        {
            ChangePanel(ActivePanel.STAGE2);
            nowSee = 1;
        }
    }

    public void Stage1()
    {
        PlayerPrefs.SetInt("Stage", 1);
        SceneManager.LoadScene("Stage1");
    }

    public void Stage2()
    {
        PlayerPrefs.SetInt("Stage", 2);
        SceneManager.LoadScene("Stage2");
    }

    public void Stage3()
    {
        PlayerPrefs.SetInt("Stage", 3);
        SceneManager.LoadScene("Stage3");
    }
}
