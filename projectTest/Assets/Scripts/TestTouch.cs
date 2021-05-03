using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTouch : MonoBehaviour
{
    private InputManager inputManager;
    private Camera cameraMain;
    private ParticleSystem particle;

    //private Raycast raycast;
    private void Start()
    {
        particle = GetComponent<ParticleSystem>();
    }
    private void Awake()
    {
        inputManager = GameObject.Find("InputManager").GetComponent<InputManager>();
        cameraMain = Camera.main;
        //raycast = GameObject.Find("AR Session Origin").GetComponent<RayCast>();
    }

    private void OnEnable()
    {
        inputManager.onStartTouch += Move;
    }

    private void OnDisable()
    {
        inputManager.onEndTouch -= Move;
    }

    public void Move(Vector2 screenPosition, float time)
    {
        Vector3 screenCoordinates = new Vector3(screenPosition.x , screenPosition.y, cameraMain.nearClipPlane);
        Vector3 worldCoordinate = cameraMain.ScreenToWorldPoint(screenCoordinates);
        //worldCoordinate.z = 0;
        transform.position = worldCoordinate;

        Debug.Log("Touch");
        particle.Play(true);
    }
}
