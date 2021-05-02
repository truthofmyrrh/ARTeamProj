using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    public LayerMask layerMask;
    //SpawnEnemies spawns;
 

    private void Start()
    {
        //spawns = GameObject.Find("EnemySpawnPosition").GetComponent<SpawnEnemies>();

    }
    // Update is called once per frame
    void FixedUpdate()
    {

        // Shoot a ray from camera through the screen point where the mouse cursor is (e.g. click and shoot).
        // Provide also a layer mask to detect only specific layers (set in the inspector).
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit2;
        if (Physics.Raycast(ray, out hit2, layerMask, 100))
        {
            // draw a debug line from the ray's origin to the hit point
            Debug.DrawLine(ray.origin, hit2.point, Color.red);
            Destroy(hit2.collider.gameObject);
        }


            
    }
}
