using Events;
using SavePrefs;
using UnityEngine;

namespace Managers
{
	public class GameManager : MonoBehaviour
	{
		private SavePrefs.SavePrefs _savePrefs;
		
		private void Start()
		{
			_savePrefs = FindObjectOfType<SavePrefs.SavePrefs>();
		}

		public void StartGame(int levelNumber)
		{
			//TODO Game logic
			WinGame(levelNumber);
		}

		private void WinGame(int levelNumber)
		{
			var d = _savePrefs.SaveData;
			d = new SaveData(levelNumber, d.Ticket, d.SuccessiveDay, d.OnEnterTime, d.FirstEnterTime);
			_savePrefs.SaveData = d;
			StaticEvents.OnLevelComplete();
			Debug.Log($"Win {levelNumber}");
		}
	}
}