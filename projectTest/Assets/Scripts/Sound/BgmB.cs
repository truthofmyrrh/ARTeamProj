using UnityEngine;
using UnityEngine.UI;

namespace ProjectTest.MainMenu
{
	[RequireComponent(typeof(Button))]
	public class BgmB : MonoBehaviour
	{
		[SerializeField] private Material musicOffIcon;
		[SerializeField] private Material musicOnIcon;
		private Image image;

		public void ToggleMusic()
		{
			Array.Instance.BgmMuted = !Array.Instance.BgmMuted;

			image.material = Array.Instance.BgmMuted ? musicOffIcon : musicOnIcon;
		}

		public void Start()
		{
			GetComponent<Button>().onClick.AddListener(ToggleMusic);
			image = GetComponent<Image>();
			image.material = Array.Instance.BgmMuted ? musicOffIcon : musicOnIcon;
		}
	}
}
