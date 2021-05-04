﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

namespace ShootAR.Menu
{
	/// <remarks>
	/// Most functions of this class are assigned as events on buttons
	/// through the Inspector in the Editor.
	/// </remarks>
	[RequireComponent(typeof(AudioSource))]
	
	public class MenuManager : MonoBehaviour
	{
		
		private AudioSource sfx;
		private bool isPlaying = true;
		private SpawnEnemies spawnE;

		[SerializeField] private GameObject mainMenu;
		[SerializeField] private GameObject subMenu;
		[SerializeField] private GameObject stageMenu;
		[SerializeField] private GameObject waveEditorMenu;
		[SerializeField] private GameObject highscoreMenu;
		[SerializeField] private AudioClip select;
		[SerializeField] private AudioClip back;



		public static Stack<string> scenes = new Stack<string>();

		private void Awake() {
#if UNITY_ANDROID && !UNITY_EDITOR
			Debug.unityLogger.logEnabled = false;
#endif
		}

		private void Start() {
			if (scenes.Count == 0)
			{
				scenes.Push(SceneManager.GetActiveScene().name);
			}
			Configuration.Instance.CreateFiles();

			Application.runInBackground = false;

			AudioListener.volume = Configuration.Instance.SoundMuted ? 0f : Configuration.Instance.Volume;

			sfx = gameObject.GetComponent<AudioSource>();
			spawnE = GameObject.Find("EnemySpawnPosition").GetComponent<SpawnEnemies>();
		}
		public void previousScene()
		{

			if (scenes.Count == 0)
			{
				Application.Quit();
			}
			else
			{
				spawnE.InitTime();
				string sceneToBuild = scenes.Pop();
				loadScene(sceneToBuild);
			}

		}

		public void loadScene(string newScene)
		{
			scenes.Push(newScene);
			SceneManager.LoadScene(newScene);

		}

		public void TostageMenu() {
			mainMenu.SetActive(false);
			subMenu.SetActive(true);
			stageMenu.SetActive(true);

			sfx.PlayOneShot(select, 1.2F);
		}

		public void StartGame(string stage) {

			//execute when game begins.
			
			SceneManager.LoadScene(stage);
			//spawnE.InitTime();
		}

		public void ToWaveEditor() {
			mainMenu.SetActive(false);
			subMenu.SetActive(true);
			waveEditorMenu.SetActive(true);

			sfx.PlayOneShot(select, 1.2F);
		}

		public void ToHighscores() {
			mainMenu.SetActive(false);
			subMenu.SetActive(true);
			highscoreMenu.SetActive(true);
		}

		public void ToMainMenu() {
			highscoreMenu.SetActive(false);
			stageMenu.SetActive(false);
			waveEditorMenu.SetActive(false);
			subMenu.SetActive(false);
			mainMenu.SetActive(true);

			//sound
			sfx.PlayOneShot(back, 1.5F);
			isPlaying = true;
		}

		public void QuitApp() {
			if (Configuration.Instance.UnsavedChanges)
				Configuration.Instance.SaveSettings();

			Application.Quit();

#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#endif
		}


		public void TurnSoundOnOff()
		{
			if(isPlaying)
            {
				sfx.Pause();

            }
            else
            {
				sfx.Play();
            }
			isPlaying = !isPlaying;
			
		}
	}
}
