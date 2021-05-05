using UnityEngine;

namespace ProjectTest
{

	[RequireComponent(typeof(AudioSource))]
	public class BgmManager : MonoBehaviour
	{
		public void Toggle()
		{
			AudioSource bgm = GetComponent<AudioSource>();

			bgm.enabled = !Array.Instance.BgmMuted;
			bgm.volume = AudioListener.volume;
		}

		public void Start() => Toggle();

		public void OnEnable() => Array.Instance.OnBgmToggle += Toggle;
		public void OnDisable() => Array.Instance.OnBgmToggle -= Toggle;
	}
}
