using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagement : MonoBehaviour
{
    // Start is called before the first frame update

    public string gameover = "Result_fail";
    public float Goal = 10;
    public string win = "Result_suc";

    void Start()
    {
        
    }

    public void Lose()
    {
        SceneManager.LoadScene(gameover);
    }

    public void Win()
    {
        SceneManager.LoadScene(win);
    }

}
