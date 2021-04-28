using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI coin;
    public TextMeshProUGUI health;

    private PlayerInfo pinfo;
    
    // Start is called before the first frame update
    void Start()
    {
        pinfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        UpdateStat();
        
    }

    public void UpdateStat()
    {
        coin.text = "Coin : " + pinfo.coin;
        health.text = "Health : " + pinfo.health;

    
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
