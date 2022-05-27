using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager_stage1 : MonoBehaviour
{

    public GameObject[] blockPanels;
    public GameObject[] toyPanels;
    public Text score;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Stage1Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
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
        score.text = PlayerPrefs.GetInt("Stage1Score").ToString();
    }
}
