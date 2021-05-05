using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectTest
{
	public class GameNavi : MonoBehaviour
	{
		[SerializeField] private GameObject playCanvas;
		[SerializeField] private GameObject pauseCanvas;
		[SerializeField] private Text score;
		[SerializeField] private Text roundIndex;
		[SerializeField] private GameState gameState;
		private AudioSource sfx;
		[SerializeField] private AudioClip pauseSfx;
#pragma warning disable CS0649
		[SerializeField] private Button pauseToMenuButton;
#pragma warning restore CS0649
		public Text Score
		{
			get { return score; }
			set { score = value; }
		}

		public Text RoundIndex
		{
			get { return roundIndex; }
			set { roundIndex = value; }
		}


		public static GameNavi Create(
				GameObject playCanvas, GameObject pauseCanvas,
				Text bulletCount, Text bulletPlus,
				Text score, Text roundIndex,
				AudioSource sfx, AudioClip pauseSfx,
				GameState gameState)
		{
			var o = new GameObject(nameof(GameNavi)).AddComponent<GameNavi>();

			o.playCanvas = playCanvas;
			o.pauseCanvas = pauseCanvas;
			o.Score = score;
			o.RoundIndex = roundIndex;
			o.sfx = sfx;
			o.pauseSfx = pauseSfx;
			o.gameState = gameState;

			return o;
		}

		public void Start()
		{

			if (pauseSfx != null)
			{
				sfx = gameObject.AddComponent<AudioSource>();
				sfx.clip = pauseSfx;
				sfx.volume = 1f;
			}

			pauseToMenuButton?.onClick.AddListener(() =>
			{
				gameState.Paused = false;
				UnityEngine.SceneManagement.SceneManager
					.LoadScene(0);
			});
		}

		public void TogglePauseMenu()
		{
			sfx.PlayOneShot(pauseSfx, 1f);

			if (!pauseCanvas.gameObject.activeSelf)
			{
				RoundIndex.text = "Round: " + gameState.Level;
				playCanvas.SetActive(false);
				pauseCanvas.SetActive(true);
				gameState.Paused = true;
			}
			else
			{
				playCanvas.SetActive(true);
				pauseCanvas.SetActive(false);
				gameState.Paused = false;
			}
		}
	}
}
