using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceCastleOnPlane : MonoBehaviour
{
    [SerializeField]
    private ARRaycastManager raycastManager;

    [SerializeField]
    private ARPlaneManager planeManager;

    [SerializeField]
    private GameObject castle;

    [SerializeField]
    private GameObject ball;

    private GameObject spawnObject;
    private GameObject ballObject;
    private bool isSet = false;

    public void StartButtonTouch()
    {
        isSet = true;
        planeManager.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlaceCastleByTouch();

        if (isSet)
        {
            UpdateCenterObject();
        }
    }

    private void PlaceCastleByTouch()
    {
        if(Input.touchCount > 0 && !isSet)
        {
            Touch touch = Input.GetTouch(0);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if(raycastManager.Raycast(touch.position, hits, TrackableType.Planes))
            {
                Pose hitPose = hits[0].pose;

                if (!castle.activeSelf)
                {
                    castle.SetActive(true);
                    castle.transform.position = hitPose.position;
                    castle.transform.rotation = hitPose.rotation;
                }
                else
                {
                    castle.transform.position = hitPose.position;
                    castle.transform.rotation = hitPose.rotation;
                }
            }
        }
    }

    private void UpdateCenterObject()
    {
        Vector3 screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0, 0.5f));

        /*
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        raycastManager.Raycast(screenCenter, hits, TrackableType.Planes);

        if(hits.Count > 0)
        {
            Pose placementPose = hits[0].pose;
            ball.SetActive(true);
            ball.transform.SetPositionAndRotation(placementPose.position + new Vector3(0, 0, 0.3f), placementPose.rotation);
        }
        else
        {
            ball.SetActive(false);
        }
        */

        if (!ball.activeSelf)
        {
            ball.SetActive(true);
            ball.transform.parent = GameObject.FindWithTag("MainCamera").transform;
            ball.transform.localPosition = new Vector3(0f, 0, 0.5f);
        }
        else
        {
        }
    }
}
