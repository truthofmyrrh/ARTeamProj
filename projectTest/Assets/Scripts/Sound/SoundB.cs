using UnityEngine;
using UnityEngine.UI;

namespace ProjectTest.MainMenu
{
	[RequireComponent(typeof(Button))]
	public class SoundB : MonoBehaviour
	{
		[SerializeField] private Material soundOffIcon;
		[SerializeField] private Material soundOnIcon;
		private Image image;

		[SerializeField] private BgmB bgmButton;

		[SerializeField] private BgmManager bgmManager;

		public void ToggleSound()
		{
			Array.Instance.SoundMuted = !Array.Instance.SoundMuted;

			if (Array.Instance.SoundMuted)
			{
				image.material = soundOffIcon;
				Array.Instance.Volume = AudioListener.volume;
				AudioListener.volume = 0.0f;

				if (!Array.Instance.BgmMuted) bgmButton.ToggleMusic();
			}
			else
			{
				image.material = soundOnIcon;
				AudioListener.volume = Array.Instance.Volume;

				if (!Array.Instance.BgmMuted) bgmManager.Toggle();
			}
		}

		private void Start()
		{
			GetComponent<Button>().onClick.AddListener(ToggleSound);
			image = GetComponent<Image>();
			image.material = Array.Instance.SoundMuted ? soundOffIcon : soundOnIcon;
		}
	}

}
