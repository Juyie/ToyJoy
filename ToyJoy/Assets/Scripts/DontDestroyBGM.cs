using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyBGM : MonoBehaviour
{
    private GameObject[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        audioSources = GameObject.FindGameObjectsWithTag("BGM");
    }

    // Update is called once per frame
    void Update()
    {
        audioSources = GameObject.FindGameObjectsWithTag("BGM");
        if (audioSources.Length > 1)
        {
            Destroy(audioSources[1]);
        }
    }
}
