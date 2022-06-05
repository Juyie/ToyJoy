using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerManager_stage3 : MonoBehaviour
{
    public GameObject[] blockPanels;
    public GameObject[] toyPanels;
    public Text score;

    public Sprite block_g;
    public Sprite block_a;
    public Sprite block_m;
    public Sprite block_e;

    public Sprite bunny;
    public Sprite bear;
    public Sprite duck;
    public Sprite dino;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Stage3Score", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeBlockPanel(int num)
    {
        blockPanels[0].GetComponent<Image>().sprite = block_g;
        blockPanels[1].GetComponent<Image>().sprite = block_a;
        blockPanels[2].GetComponent<Image>().sprite = block_m;
        blockPanels[3].GetComponent<Image>().sprite = block_e;
    }

    public void ChangeToyPanel(int num)
    {
        toyPanels[0].GetComponent<Image>().sprite = bunny;
        toyPanels[1].GetComponent<Image>().sprite = bear;
        toyPanels[2].GetComponent<Image>().sprite = duck;
        toyPanels[2].GetComponent<Image>().sprite = dino;
    }

    public void UpdateScore()
    {
        score.text = PlayerPrefs.GetInt("Stage3Score").ToString();
    }
}
