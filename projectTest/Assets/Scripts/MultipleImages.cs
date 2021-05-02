using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

// based on:  https://www.youtube.com/watch?v=I9j3MD7gS5Y 

[RequireComponent (typeof(ARTrackedImageManager))]
public class MultipleImages : MonoBehaviour
{

    private ARTrackedImageManager trackedImgMgr;

    public PlaceablePrefab[] placeablePrefabs;

    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
  
    // Start is called before the first frame update
    void Awake()
    {
        trackedImgMgr = FindObjectOfType<ARTrackedImageManager>();

        foreach(PlaceablePrefab prefab in placeablePrefabs)
        {
            GameObject go = Instantiate(prefab.prefab, Vector3.zero, Quaternion.identity);
            go.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, go);
        }
    }

    public void OnEnable()
    {
        // subscribing to the trackedImageChanged event
        trackedImgMgr.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        // subscribing to the trackedImageChanged event
        trackedImgMgr.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {

        foreach (ARTrackedImage img in args.added) 
        {
            UpdateImage(img);
        }

        foreach (ARTrackedImage img in args.updated)
        {
            UpdateImage(img);
        }

        foreach (ARTrackedImage img in args.removed)
        {
            
            spawnedPrefabs[img.referenceImage.name].SetActive(false);
            UpdateImage(img);
        }
    }

    private void UpdateImage(ARTrackedImage img)
    {

        string imgName = img.referenceImage.name;
        GameObject prefab = spawnedPrefabs[imgName];

        if (img.trackingState == TrackingState.Tracking)
        {
            prefab.transform.position = img.transform.position;
            //prefab.transform.rotation = img.transform.rotation;
            prefab.SetActive(true);

            /* // this code disables all other game objects
            foreach(GameObject go in spawnedPrefabs.Values)
            {
                if (go.name != imgName)
                    go.SetActive(false);

            }*/
        }
        else if(img.trackingState == TrackingState.Limited || img.trackingState == TrackingState.None)
        {
            prefab.SetActive(false);
        }

        
    }

    [System.Serializable]
    public struct PlaceablePrefab
    {
        public string name;
        public GameObject prefab;
    }
}

