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

    public Sprite block_l;
    public Sprite block_o;
    public Sprite block_v;
    public Sprite block_e;

    public Sprite bunny;
    public Sprite bear;
    public Sprite duck;


    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Stage2Score", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeBlockPanel(int num)
    {
        blockPanels[0].GetComponent<Image>().sprite = block_l;
        blockPanels[1].GetComponent<Image>().sprite = block_o;
        blockPanels[2].GetComponent<Image>().sprite = block_v;
        blockPanels[3].GetComponent<Image>().sprite = block_e;
    }

    public void ChangeToyPanel(int num)
    {
        toyPanels[0].GetComponent<Image>().sprite = bunny;
        toyPanels[1].GetComponent<Image>().sprite = bear;
        toyPanels[2].GetComponent<Image>().sprite = duck;
    }

    public void UpdateScore()
    {
        score.text = PlayerPrefs.GetInt("Stage2Score").ToString();
    }
}
