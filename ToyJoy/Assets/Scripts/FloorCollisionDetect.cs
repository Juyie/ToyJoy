using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloorCollisionDetect : MonoBehaviour
{
    [SerializeField]
    private Text text;

    private bool first = false;

    // Start is called before the first frame update
    void Start()
    {
        
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
            // This
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
}
