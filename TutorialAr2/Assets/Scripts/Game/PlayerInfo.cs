using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 3;
    public float coin = 0;

    private GameObject canvas;
    //private GameUI ui;
    
    

    void Start()
    {
        canvas = GameObject.Find("Canvas");
        
    }

    public void ChangeHealth(float value)
    {
        health = value;
        
    }

    public void ChangeCoin(float value)
    {
        coin = value;
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
