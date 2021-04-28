using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

[DefaultExecutionOrder(-1)]
public class InputManager : MonoBehaviour
{
    private TouchControl touch;
    public delegate void StartTouchEvent(Vector2 position, float time);
    public event StartTouchEvent onStartTouch;
    public delegate void EndTouchEvent(Vector2 position, float time);
    public event EndTouchEvent onEndTouch;

    private void Awake()
    {
        touch = new TouchControl();
    }
    private void OnEnable()
    {
        touch.Enable();
        TouchSimulation.Enable();
        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown += FingerDown;

    }

    private void OnDisable()
    {
        touch.Disable();
        TouchSimulation.Disable();

        UnityEngine.InputSystem.EnhancedTouch.Touch.onFingerDown -= FingerDown;

    }

    private void Start()
    {
        touch.Touches.PressOn.started += ctx => StartTouch(ctx);
        touch.Touches.PressOn.canceled += ctx => EndTouch(ctx);

    }

    private void StartTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("Touch Started" + touch.Touches.Touchpos.ReadValue<Vector2>());

        if (onStartTouch != null) onStartTouch(touch.Touches.Touchpos.ReadValue<Vector2>(), (float)context.startTime);
    }

    private void EndTouch(InputAction.CallbackContext context)
    {
        //Debug.Log("Touch ended");

        if (onEndTouch != null) onEndTouch(touch.Touches.Touchpos.ReadValue<Vector2>(), (float)context.time);
    }

    private void FingerDown(Finger finger)
    {
        if (onStartTouch != null) onStartTouch(finger.screenPosition, Time.time);
    }

    private void Update()
    {
       // Debug.Log(UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches);
       /*
        foreach(UnityEngine.InputSystem.EnhancedTouch.Touch touch in UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches)
        {
            //Debug.Log(touch.phase == UnityEngine.InputSystem.TouchPhase.Began);
        }*/
    }

}
