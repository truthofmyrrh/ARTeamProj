using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent (typeof(ARTrackedImageManager))]
public class MultiTrack : MonoBehaviour
{
    private ARTrackedImageManager trackImageManager;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    public PlaceablePrefab[] placeablePrefabs;

   
    // Start is called before the first frame update
    private void Awake()
    {
        trackImageManager = FindObjectOfType<ARTrackedImageManager>();
        foreach(PlaceablePrefab prefab in placeablePrefabs)
        {
            GameObject g = Instantiate(prefab.prefab,Vector3.zero,Quaternion.identity);
            g.name = prefab.name;
            spawnedPrefabs.Add(prefab.name, g);
        }
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
            UpdateImage(img);
   
        }

        foreach(ARTrackedImage img in args.updated)
        {
            UpdateImage(img);
        }

        foreach(ARTrackedImage img in args.removed)
        {
            spawnedPrefabs[img.referenceImage.name].SetActive(false);
            UpdateImage(img);
        }
    }

    private void UpdateImage(ARTrackedImage img)
    {
        string imgName = img.referenceImage.name;
        GameObject prefab = spawnedPrefabs[imgName];
        if(img.trackingState== TrackingState.Tracking)
        {
            prefab.transform.position = img.transform.position;

            prefab.SetActive(true);
        }

        else if(img.trackingState == TrackingState.Limited)
        {
            prefab.SetActive(false);
        }

        else // None
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
