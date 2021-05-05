using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;


public class monsterController : MonoBehaviour
{
    
    
    public float movementSpeed = 0.3f;
        
    public GameObject target;
    private GameUI uiManager;
    

    void Start()
    {
        uiManager = GameObject.Find("PlayManager").GetComponent<GameUI>();
        target = GameObject.Find("AR Session Origin").transform.GetChild(0).transform.GetChild(0).gameObject;
        
    }
 
    void Update()
    {
        
        Vector3 forward = target.transform.position - transform.position;
        
        transform.Translate(forward.normalized * Time.deltaTime * movementSpeed);
        Vector3 lookVector = target.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, 1);

        //https://answers.unity.com/questions/1409312/how-do-i-make-my-enemy-look-at-player-on-only-one.html



    }




    private void OnTriggerEnter(Collider other)
    {

       
        if(other.gameObject.CompareTag("Player"))
        {

            // collision with player

            Debug.Log("Destroyed");
            uiManager.SubstractHealth();
            Destroy(gameObject);

            
            
            
        }
    }
    
}
