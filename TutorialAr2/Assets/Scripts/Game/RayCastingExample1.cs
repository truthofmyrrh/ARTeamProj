using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class RayCastingExample1 : MonoBehaviour
{
    public GameObject objectToInstantiate;
    SpawnEnemies spawns;
    
    private ARRaycastManager raycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();



    // Start is called before the first frame update
    void Start()
    {
        raycastManager = GetComponent<ARRaycastManager>();
        
    
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }



    void Update()
    {
        if (TryGetTouchPosition(out Vector2 touchPosition))
        {

            Ray ray = Camera.main.ScreenPointToRay(touchPosition);


            if (raycastManager.Raycast(ray, hits, TrackableType.All))
            {
                Pose hitPose = hits[0].pose;

                


            }
        }




    }

   
}
