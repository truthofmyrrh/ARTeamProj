using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using System;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class RayCast : MonoBehaviour
{
   
    private RaycastHit2D hit;
    private Vector2[] touches = new Vector2[5];
    private Vector3 hitPose;
    private PlayerInfo pinfo;
    public ParticleSystem particle;
    public LayerMask layermask;

    private void Start()
    {
        pinfo = GameObject.Find("AR Session Origin").transform.GetChild(1).GetComponent<PlayerInfo>();
    }

    public Vector3 getHitpos()
    {
        return hitPose;
    }
    private void Update()
    {


        Ray ray = Camera.main.ScreenPointToRay(Touchscreen.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, layermask))
        {
            //If player tap onto the enemy then it would be distroyed with particle.


            hitPose = hit.transform.position;

            Destroy(hit.collider.gameObject);
            Instantiate(particle, hit.transform);
            particle.Play(true);

            pinfo.ChangeCoin(pinfo.coin + 1);


                

        }


        
    }

}

    /*
    public void DestroyEnemy(Vector3 pos)
    {

        foreach (GameObject enemy in spawns.EnemiesSpawned)
        {
            float xGap = pos.x - enemy.transform.position.x;
            float zGap = pos.z - enemy.transform.position.z;
            float yGap = pos.y - enemy.transform.position.y;

            bool includeY = Mathf.Abs(yGap) <= enemy.transform.localScale.y;
            bool includeX = Mathf.Abs(xGap) <= enemy.transform.localScale.x;
            bool includeZ = Mathf.Abs(zGap) <= enemy.transform.localScale.z;


            Debug.Log("pos.x " + pos.x + " pos.z " + pos.z + "pos.y " + pos.y);
            Debug.Log("inx " + includeX + "iny " + includeY + "includez " + includeZ);
            if (includeY && includeZ)
            {
                spawns.EnemiesSpawned.Remove(enemy);
                
                break;
            }
        }
    }*/

