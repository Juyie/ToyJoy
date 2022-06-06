using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageChoose : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject[] stage1StarPanels;
    public GameObject[] stage2StarPanels;
    public GameObject[] stage3StarPanels;
    public int nowSee;
    public Text lastScoreUIForStage1;
    public Text lastScoreUIForStage2;
    public Text lastScoreUIForStage3;

    private GameObject BGM;

    public Sprite yellowStar;

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
        ChangeStars();
        lastScoreUIForStage1.text = "High Score:" + PlayerPrefs.GetInt("Stage1lastScore") + "";
        lastScoreUIForStage2.text = "High Score:" + PlayerPrefs.GetInt("Stage2lastScore") + "";
        lastScoreUIForStage3.text = "High Score:" + PlayerPrefs.GetInt("Stage3lastScore") + "";
        ChangePanel(ActivePanel.STAGE1);
        nowSee = 0;
        BGM = GameObject.FindWithTag("BGM");
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
        Destroy(BGM);
        PlayerPrefs.SetInt("Stage", 1);
        StartCoroutine("WaitAndGo", "Stage1");
    }

    public void Stage2()
    {
        Destroy(BGM);
        PlayerPrefs.SetInt("Stage", 2);
        StartCoroutine("WaitAndGo", "Stage2");
    }

    public void Stage3()
    {
        Destroy(BGM);
        PlayerPrefs.SetInt("Stage", 3);
        StartCoroutine("WaitAndGo","Stage3");
    }

    public void ChangeStars()
    {
        GetStarCount(1, PlayerPrefs.GetInt("Stage1lastScore"));
        GetStarCount(2, PlayerPrefs.GetInt("Stage2lastScore"));
        GetStarCount(3, PlayerPrefs.GetInt("Stage3lastScore"));
    }

    public void GetStarCount(int stage,int num)
    {
        if (stage == 1)
        {
            if (num >= 44)
            {
                stage1StarPanels[0].GetComponent<Image>().sprite = yellowStar;
            }
            if(num >= 88)
            {
                stage1StarPanels[1].GetComponent<Image>().sprite = yellowStar;
            }
            if(num >= 132)
            {
                stage1StarPanels[2].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 176)
            {
                stage1StarPanels[3].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 220)
            {
                stage1StarPanels[4].GetComponent<Image>().sprite = yellowStar;
            }

        }else if(stage == 2)
        {
            if (num >= 64)
            {
                stage2StarPanels[0].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 128)
            {
                stage2StarPanels[1].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 192)
            {
                stage2StarPanels[2].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 256)
            {
                stage2StarPanels[3].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 320)
            {
                stage2StarPanels[4].GetComponent<Image>().sprite = yellowStar;
            }
        }
        else
        {
            if (num >= 80)
            {
                stage3StarPanels[0].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 160)
            {
                stage3StarPanels[1].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 240)
            {
                stage3StarPanels[2].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 320)
            {
                stage3StarPanels[3].GetComponent<Image>().sprite = yellowStar;
            }
            if (num >= 400)
            {
                stage3StarPanels[4].GetComponent<Image>().sprite = yellowStar;
            }
        }
        
    }

    IEnumerator WaitAndGo(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
