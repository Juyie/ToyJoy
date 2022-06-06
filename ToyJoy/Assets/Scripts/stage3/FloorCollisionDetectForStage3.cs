using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloorCollisionDetectForStage3 : MonoBehaviour
{
    public bool isFeverTime = false;
    public int countToy = 0;
    public int countBlock = 0;
    public playerManager_stage3 playerManager;

    [SerializeField]
    private Text text;

    private bool first = false;

    [SerializeField]
    private AudioSource audioSourceBGM;

    [SerializeField]
    private AudioClip feverClip;

    [SerializeField]
    private AudioSource audioSourceBlockUI;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<playerManager_stage3>();
        countBlock = 0;
        countToy = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!first)
        {
            StartCoroutine("WaitForReady");
        }
        if (first && collision.transform.tag != "Ball")
        {
            // collision detect
            if (collision.collider.gameObject.CompareTag("Block"))
            {
                PlayerPrefs.SetInt("Stage3Score", PlayerPrefs.GetInt("Stage3Score") + 20);

                audioSourceBlockUI.Play();
                countBlock++;
                GetOrder(collision.collider.gameObject);
                playerManager.UpdateScore();
                if (countBlock == 4)
                {
                    isFeverTime = true;
                    if (audioSourceBGM.clip != feverClip)
                    {
                        audioSourceBGM.clip = feverClip;
                        audioSourceBGM.Play();
                    }
                }
            }
            else if (collision.collider.gameObject.CompareTag("Toy"))
            {
                if (isFeverTime)
                {
                    PlayerPrefs.SetInt("Stage3Score", PlayerPrefs.GetInt("Stage3Score") + 80);
                }
                else
                {
                    PlayerPrefs.SetInt("Stage3Score", PlayerPrefs.GetInt("Stage3Score") + 40);

                }
                countToy++;
                GetOrder(collision.collider.gameObject);
                playerManager.UpdateScore();
                if (countToy == 4)
                {
                    SceneManager.LoadScene("Score");
                }
            }
            else if (collision.collider.gameObject.CompareTag("WarningToy"))
            {
                SceneManager.LoadScene("Score");
            }

            //text.text = collision.transform.name;
            StartCoroutine("DestroyBlock", collision.transform.gameObject);
        }
    }

    IEnumerator WaitForReady()
    {
        yield return new WaitForSeconds(2f);
        first = true;
    }

    IEnumerator DestroyBlock(GameObject block)
    {
        yield return new WaitForSeconds(2f);
        Destroy(block);
    }

    private void GetOrder(GameObject myobject)
    {
        string myName = myobject.name;

        switch (myName)
        {
            case "Block_G":
                playerManager.ChangeBlockPanel(0);
                break;
            case "Block_A":
                playerManager.ChangeBlockPanel(1);
                break;
            case "Block_M":
                playerManager.ChangeBlockPanel(2);
                break;
            case "Block_E":
                playerManager.ChangeBlockPanel(3);
                break;
            case "Bunny_01":
                playerManager.ChangeToyPanel(0);
                break;
            case "TeddyBear_01":
                playerManager.ChangeToyPanel(1);
                break;
            case "RubberDuck_01":
                playerManager.ChangeToyPanel(2);
                break;
            case "Dinosaur_01":
                playerManager.ChangeToyPanel(3);
                break;
        }
    }
}
