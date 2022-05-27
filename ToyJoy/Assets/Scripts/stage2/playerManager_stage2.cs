using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager_stage2 : MonoBehaviour
{
    public GameObject[] blockPanels;
    public GameObject[] toyPanels;
    public Text score;
    public int shootChance = 7;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Stage2Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (shootChance == 0)
        {
            SceneManager.LoadScene("Score");

        }
    }

    public void ChangeBlockPanel(int num)
    {
        blockPanels[num].GetComponent<Image>().color = Color.white;
    }

    public void ChangeToyPanel(int num)
    {
        toyPanels[num].GetComponent<Image>().color = Color.white;
    }

    public void UpdateScore()
    {
        score.text = PlayerPrefs.GetInt("Stage2Score").ToString();
    }
}
