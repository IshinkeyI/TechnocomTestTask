using System.Collections.Generic;
using UnityEngine;

namespace Managers.Sound
{
	public class SoundManager : MonoBehaviour
	{
		[SerializeField] private List<AudioSource> musicAudioSources;
		[SerializeField] private List<AudioSource> speakerAudioSources;


		#region Properties
		public List<AudioSource> MusicAudioSources => musicAudioSources;
		public List<AudioSource> SpeakerAudioSources => speakerAudioSources;
		#endregion
	}
}