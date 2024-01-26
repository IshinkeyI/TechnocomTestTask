using System;
using Managers.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
	public class SoundSettings : MonoBehaviour
	{
		[SerializeField] private Button musicButton;
		[SerializeField] private Button speakerButton;

		private SoundManager _soundManager;
		
		private void Awake()
		{
			_soundManager = FindObjectOfType<SoundManager>();
			musicButton.onClick.AddListener(ChangeMusicState);
			speakerButton.onClick.AddListener(ChangeSpeakerState);
		}

		private void ChangeMusicState()
		{
			foreach (var mas in _soundManager.MusicAudioSources)
			{
				mas.mute = !mas.mute;
			}
		}
		
		private void ChangeSpeakerState()
		{
			foreach (var mas in _soundManager.SpeakerAudioSources)
			{
				mas.mute = !mas.mute;
			}
		}
	}
}