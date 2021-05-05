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
		
		uiCanvas = GameObject.Find("UIManager").transform.GetChild(1).gameObject;
		CalculateHealth();
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
			return;
        }
		currenthealth--;
		health[(int)currenthealth].SetActive(false);
		//health.RemoveAt((int)currenthealth);
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
		int i = 0;
		GameObject h;
		Debug.Log(uiCanvas.name);
		while( uiCanvas.transform.GetChild(5).GetChild(i) != null)
		{
			h = uiCanvas.transform.GetChild(5).GetChild(i).gameObject;
			health.Add(h);
			maxhealth++;
			if (h.activeInHierarchy)
			{
				currenthealth++;
			}

			

			i++;
		}
	}

	public void InitHealth()
    {
		int i = 0;
		while (uiCanvas.transform.GetChild(5).GetChild(i) != null)
        {
			health[i].SetActive(true);
			i++;
        }

	}

}
