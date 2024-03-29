using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BallController : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private Camera cam;

    [SerializeField]
    private float ballThrowingForce;

    [SerializeField]
    private int totalBallCount;

    private bool isTouched = false;
    private int ballCount = 0;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private AudioSource audioSourceCollision;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GetComponent<Rigidbody>();
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.touchCount == 1 || Input.GetMouseButtonDown(0)) && !isTouched)
        {
            audioSource.Play();
            isTouched = true;
            transform.parent = null;
            ballRigidbody.useGravity = true;
            ballRigidbody.isKinematic = false;
            ballRigidbody.velocity = cam.transform.rotation * new Vector3(0, 1, 1) * ballThrowingForce;
            ballCount++;
            if (ballCount == totalBallCount)
            {
                Invoke("LoadScoreScene",3);
            }
            if (ballCount < totalBallCount)
            {
                Invoke("RespawnBall", 3);
            }
        }
    }

    private void RespawnBall()
    {
        isTouched = false;
        ballRigidbody.useGravity = false;
        ballRigidbody.isKinematic = true;
        ballRigidbody.velocity = new Vector3(0, 0, 0);
        transform.parent = cam.transform;
        transform.localPosition = new Vector3(0f, 0, 0.5f);
    }

    private void LoadScoreScene()
    {
        SceneManager.LoadScene("Score");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.CompareTag("Block") || collision.collider.gameObject.CompareTag("Toy"))
        {
            audioSourceCollision.Play();
        }
    }
}
