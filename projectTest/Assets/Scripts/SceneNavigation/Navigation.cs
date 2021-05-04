using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// https://stackoverflow.com/a/53542474/12451939

namespace ProjectTest.MainMenu
{
	
	[RequireComponent(typeof(AudioSource))]

	public class Navigation : MonoBehaviour
	{

		private AudioSource sfx;

		[SerializeField] private GameObject mainMenu;
		[SerializeField] private GameObject subMenu;
		[SerializeField] private GameObject stageMenu;
		[SerializeField] private GameObject storeMenu;
		[SerializeField] private GameObject gunsMenu;
		[SerializeField] private GameObject itemsMenu;
		[SerializeField] private AudioClip select;
		[SerializeField] private AudioClip back;

		public static Stack<string> scenes = new Stack<string>();

		private void Awake()
		{
#if UNITY_ANDROID && !UNITY_EDITOR
			Debug.unityLogger.logEnabled = false;
#endif
		}
		void Start()
		{
			if (scenes.Count == 0)
			{
				scenes.Push(SceneManager.GetActiveScene().name);
			}

			Application.runInBackground = false;

			AudioListener.volume = Array.Instance.SoundMuted ? 0f : Array.Instance.Volume;

			sfx = gameObject.GetComponent<AudioSource>();
		}


		public void previousScene()
		{

			if (scenes.Count == 1)
			{
				SceneManager.LoadScene("MainMenu");
			}
			else
			{
				scenes.Pop();
				string sceneToBuild = scenes.Pop();
				loadScene(sceneToBuild);
			}

		}

		public void loadScene(string newScene)
		{
			scenes.Push(newScene);
			SceneManager.LoadScene(newScene);
		}


		public void ToStartMenu()
		{
			mainMenu.SetActive(false);
			subMenu.SetActive(true);
			stageMenu.SetActive(true);

			sfx.PlayOneShot(select, 1.2F);
		}

		public void StartS1Game()
		{
			SceneManager.LoadScene("Stage1");
		}
		public void StartS2Game()
		{
			SceneManager.LoadScene("Stage2");
		}
		public void StartS3Game()
		{
			SceneManager.LoadScene("Stage3");
		}
		public void StartS4Game()
		{
			SceneManager.LoadScene("Stage4");
		}
		public void ToStoreEditor()
		{
			mainMenu.SetActive(false);
			subMenu.SetActive(true);
			storeMenu.SetActive(true);

			sfx.PlayOneShot(select, 1.2F);
		}

		public void ToHighscores()
		{
			mainMenu.SetActive(false);
			subMenu.SetActive(true);
		}

		public void ToMainMenu()
		{
			stageMenu.SetActive(false);
			storeMenu.SetActive(false);
			subMenu.SetActive(false);
			mainMenu.SetActive(true);

			sfx.PlayOneShot(back, 1.5F);
		}
		public void ToGunsMenu()
		{
			SceneManager.LoadScene("Gun");

			sfx.PlayOneShot(back, 1.5F);
		}
		public void ToItemsMenu()
		{
			SceneManager.LoadScene("Item");

			sfx.PlayOneShot(back, 1.5F);
		}

		public void QuitApp()
		{
			Application.Quit();

#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}
	}
}

