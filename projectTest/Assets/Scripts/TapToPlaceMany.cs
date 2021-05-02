using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class TapToPlaceMany : MonoBehaviour
{

    public GameObject objectToInstantiate;

    private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private GameObject spawned; 


    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }


    // Update is called once per frame
    void Update()
    {
        if(TryGetTouchPosition(out Vector2 touchPosition))
        {
            // create a ray from the camera at the mouse position
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);

            // perform raycast
            if (raycastManager.Raycast(ray, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                
                if (spawned == null)
                    spawned = Instantiate(objectToInstantiate, hitPose.position, hitPose.rotation);
                else
                {
                    spawned.transform.position = hitPose.position + Vector3.up*(spawned.transform.localScale.y/2);
                }
            }
        }


      

    }
}
