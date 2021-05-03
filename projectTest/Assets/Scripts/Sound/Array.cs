using UnityEngine;

namespace ProjectTest
{
	public class Array
	{
		private static Array instance;
		public static Array Instance
		{
			get
			{
				if (instance == null) instance = new Array();

				return instance;
			}
		}

		private delegate void SlotChangedHandler();
		private event SlotChangedHandler OnSlotChanged;

		private int spawnPatternSlot;
		public int SpawnPatternSlot
		{
			get => spawnPatternSlot;

			set
			{
				spawnPatternSlot = value;
				UnsavedChanges = true;

				OnSlotChanged?.Invoke();
			}
		}

		
		private bool soundMuted = false;

		public bool SoundMuted
		{
			get => soundMuted;

			set
			{
				soundMuted = value;
				UnsavedChanges = true;
			}
		}

		public delegate void BgmMutedHandler();
		public event BgmMutedHandler OnBgmToggle;

		private bool bgmMuted = false;
		public bool BgmMuted
		{
			get => bgmMuted;

			set
			{
				bgmMuted = value;
				UnsavedChanges = true;

				OnBgmToggle?.Invoke();
			}
		}

		private float volume = 1f;

		public float Volume
		{
			get => volume;

			set
			{
				volume = value;
				UnsavedChanges = true;
			}
		}

		public bool UnsavedChanges { get; private set; } = false;
	}
}
