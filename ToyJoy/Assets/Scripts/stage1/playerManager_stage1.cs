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
    
    public Sprite block_t;
    public Sprite block_o;
    public Sprite block_p;

    public Sprite bunny;
    public Sprite bear;


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
        if(num == 0)
            blockPanels[0].GetComponent<Image>().sprite = block_t;
        else if(num == 1)
            blockPanels[1].GetComponent<Image>().sprite = block_o;
        else if(num == 2)
            blockPanels[2].GetComponent<Image>().sprite = block_p;
    }

    public void ChangeToyPanel(int num)
    {
        if(num == 0)
            toyPanels[0].GetComponent<Image>().sprite = bunny;
        else if(num == 1)
            toyPanels[1].GetComponent<Image>().sprite = bear;
    }

    public void UpdateScore()
    {
        score.text = PlayerPrefs.GetInt("Stage1Score").ToString();
    }
}
