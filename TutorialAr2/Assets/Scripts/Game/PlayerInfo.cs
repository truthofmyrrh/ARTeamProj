using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 3;
    public float coin = 0;

    private GameUI ui;
    
    

    void Start()
    {
        ui = GameObject.Find("Canvas").GetComponent<GameUI>();
    }

    public void ChangeHealth(float value)
    {
        health = value;
        ui.UpdateStat();
    }

    public void ChangeCoin(float value)
    {
        coin = value;
        ui.UpdateStat();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
