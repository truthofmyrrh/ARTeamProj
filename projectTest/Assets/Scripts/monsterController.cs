using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class monsterController : MonoBehaviour
{
    public GameObject target;

    private ARSession arsession;

    void Start()
    {
        arsession = GameObject.FindObjectOfType<ARSession>();
    }
 
    void Update()
    {
        

    }
}
