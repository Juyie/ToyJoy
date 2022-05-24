using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorCollisionDetect : MonoBehaviour
{
    public bool isFeverTime = false;
    public int countToy = 0;
    public int countBlock = 0;
    public playerManager_stage1 playerManager;

    [SerializeField]
    private Text text;

    private bool first = false;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.Find("PlayerManager").GetComponent<playerManager_stage1>();
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
                PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 20);

                countBlock++;
                GetOrder(collision.collider.gameObject);
                playerManager.UpdateScore();
                if (countBlock == 3)
                {
                    isFeverTime = true;
                }

            }
            else if (collision.collider.gameObject.CompareTag("Toy"))
            {
                if (isFeverTime)
                {
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 80);
                }
                else
                {
                    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 40);

                }
                countToy++;
                GetOrder(collision.collider.gameObject);
                playerManager.UpdateScore();
                if (countToy == 2)
                {
                    //load scoreScene
                }

            }

            text.text = collision.transform.name;
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
            case "Block_T":
                playerManager.ChangeBlockPanel(0);
                break;
            case "Block_O":
                playerManager.ChangeBlockPanel(1);
                break;
            case "Block_P":
                playerManager.ChangeBlockPanel(2);
                break;
            case "Bunny_01":
                playerManager.ChangeToyPanel(0);
                break;
            case "TeddyBear_01":
                playerManager.ChangeToyPanel(1);
                break;
        }
    }
}
