using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour
{
    [SerializeField]
    private GameObject[] UIs;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("WaitAndTurnOn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator WaitAndTurnOn()
    {
        yield return new WaitForSeconds(2f);
        for(int i = 0; i < UIs.Length; i++)
        {
            UIs[i].SetActive(true);
        }
    }
}
