using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI coin;
    public TextMeshProUGUI health;

    private GameObject player;
    private PlayerInfo pinfo ;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        pinfo = player.GetComponent<PlayerInfo>();
        
        
    }

    public void UpdateStat()
    {
        Debug.Log("p coin " + pinfo.coin + " health " +pinfo.health);
        coin.text = "Coin : " + pinfo.coin;
        health.text = "Health : " + pinfo.health;

    
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
