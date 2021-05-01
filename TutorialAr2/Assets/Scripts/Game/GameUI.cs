using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameUI : MonoBehaviour
{
	private float maxhealth = 0;
	private float currenthealth = 0;
	private float boostHealthValue = 1;
	private List<GameObject> health;

	private string FailedScene = "Result_fail";


	private GameObject uiCanvas;
	// Start is called before the first frame update
	void Start()
    {
		health = new List<GameObject>();
		CalculateHealth();
		uiCanvas = GameObject.Find("UIManager").transform.GetChild(1).gameObject;
	}

    // Update is called once per frame
    void Update()
    {
        
    }

	public void SubstractHealth()
	{
		if(currenthealth == 0)
        {
			SceneManager.LoadScene(FailedScene);
        }
		currenthealth--;
		health[(int)currenthealth].SetActive(false);
		health.RemoveAt((int)currenthealth);
	}

	public void boosthealth()
	{
		if (health[(int)currenthealth].activeInHierarchy)
		{
			currenthealth++;
		}

		health[(int)currenthealth].SetActive(true);
	}


	public void CalculateHealth()
	{
		foreach (GameObject h in uiCanvas.transform.GetChild(5))
		{
			health.Add(h);
			maxhealth++;
			if (h.activeInHierarchy)
			{
				currenthealth++;
			}
		}
	}
}
