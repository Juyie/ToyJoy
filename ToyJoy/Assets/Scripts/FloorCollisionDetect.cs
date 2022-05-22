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
        if(collision.rigidbody.velocity.y > 0)
        {
            text.text = collision.transform.name;
            StartCoroutine("DestroyBlock", collision.transform.gameObject);
        }

        /*
        if (!first)
        {
            new WaitForSeconds(2f);
            first = true;
        }
        if (first)
        {
            text.text = collision.transform.name;
            StartCoroutine("DestroyBlock", collision.transform.gameObject);
        }
        */
    }

    IEnumerator DestroyBlock(GameObject block)
    {
        yield return new WaitForSeconds(2f);
        Destroy(block);
    }
}
