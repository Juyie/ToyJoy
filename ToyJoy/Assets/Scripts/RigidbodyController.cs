using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody[] rigidbodies;

    public void SetRigidBodies(bool isOn)
    {
        if (isOn)
        {
            for (int i = 0; i < rigidbodies.Length; i++)
            {
                rigidbodies[i].useGravity = true;
                rigidbodies[i].isKinematic = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
