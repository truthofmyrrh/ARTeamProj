using UnityEngine;
using UnityEngine.SceneManagement;

namespace ProjectTest
{
	public class GameState : MonoBehaviour
	{
		public delegate void GameOverHandler();
		public event GameOverHandler OnGameOver;
		public delegate void RoundWonHandler();
		public event RoundWonHandler OnRoundWon;
		public delegate void PauseHandler();
		public event PauseHandler OnPause;
		public delegate void RoundStartHandler();
		public event RoundStartHandler OnRoundStart;

		public int Level { get; set; }

		private bool gameOver;

		public bool GameOver
		{
			get { return gameOver; }
			set
			{
				gameOver = value;
				if (value)
				{
					RoundStarted = false;
					OnGameOver?.Invoke();
#if DEBUG
					SceneManager.LoadScene(3);
#endif
				}
			}
		}

		private bool roundWon;
		public bool RoundWon
		{
			get { return roundWon; }
			set
			{
				roundWon = value;
				if (value)
				{
					RoundStarted = false;
					OnRoundWon?.Invoke();
#if DEBUG
					SceneManager.LoadScene(2);
#endif
				}
			}
		}

		private bool paused;
		public bool Paused
		{
			get { return paused; }
			set
			{
				paused = value;
				Time.timeScale = value ? 0f : 1f;
				Time.fixedDeltaTime = value ? 0f : 0.02f;   
				if (value && OnPause != null) OnPause();
			}
		}

		private bool roundStarted;
		public bool RoundStarted
		{
			get => roundStarted;
			set
			{
				roundStarted = value;
				if (value && OnRoundStart != null) OnRoundStart();
			}
		}

		public static GameState Create(int level)
		{
			var o = new GameObject(nameof(GameState)).AddComponent<GameState>();

			o.Level = level;

			return o;
		}
	}
}
