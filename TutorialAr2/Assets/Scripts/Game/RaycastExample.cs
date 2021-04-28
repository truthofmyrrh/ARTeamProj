using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public LayerMask layerMask; 
 
     // Update is called once per frame
    void FixedUpdate()
    {
       
        // shoot a ray max. 10 units forward from the object's position 
        if (Physics.Raycast(transform.position, transform.forward, 10))
            Debug.Log("The ray hit something!");

        // shoot a ray from the object's position downward, store hit information.
        // Here the ray length is infinite
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
            Debug.Log("Found: " + hit.collider.gameObject.name +", "+ hit.distance);


        // Shoot a ray from camera through the screen point where the mouse cursor is (e.g. click and shoot).
        // Provide also a layer mask to detect only specific layers (set in the inspector).
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        if (Physics.Raycast(ray, out hit2, layerMask, 100))
            // draw a debug line from the ray's origin to the hit point
            Debug.DrawLine(ray.origin, hit2.point, Color.red);  



            
    }
}
