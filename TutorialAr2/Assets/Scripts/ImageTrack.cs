using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageTrack : MonoBehaviour
{
    private ARTrackedImageManager trackImageManager;
    private GameObject spawned;

    public GameObject gameObjectToInstantiate;

    // Start is called before the first frame update
    private void Awake()
    {
        trackImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    private void OnEnable()
    {
        trackImageManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        trackImageManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach(ARTrackedImage img in args.added)
        {
            if(img.referenceImage.name == "Ajou")
            {
                if(spawned = null)
                {
                    spawned = Instantiate(gameObjectToInstantiate, img.transform.position, img.transform.rotation);
                }
            }
        }

        foreach(ARTrackedImage img in args.updated)
        {
            UpdateImage(img);
        }

        foreach(ARTrackedImage img in args.removed)
        {
            spawned.SetActive(false);
        }
    }

    private void UpdateImage(ARTrackedImage img)
    {
        if(img.trackingState== TrackingState.Tracking)
        {
            spawned.transform.position = img.transform.position;
            //spawned.transform.rotation = img.transform.rotation;
            spawned.SetActive(true);
        }

        else if(img.trackingState == TrackingState.Limited)
        {
            spawned.SetActive(false);
        }

        else // None
        {
            spawned.SetActive(false);
        }
    }
}
