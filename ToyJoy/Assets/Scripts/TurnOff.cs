using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOff : MonoBehaviour
{
    [SerializeField]
    private GameObject nextUI;

    [SerializeField]
    private bool hasNext;

    [SerializeField]
    private float seconds;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TurnOffForSeconds");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TurnOffForSeconds()
    {
        yield return new WaitForSeconds(seconds);
        if (hasNext)
            nextUI.SetActive(true);
        gameObject.SetActive(false);
    }
}
