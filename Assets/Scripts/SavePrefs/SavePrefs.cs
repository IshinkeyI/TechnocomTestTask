using System;
using UnityEngine;

namespace SavePrefs
{
	public class SaveData
	{
		public readonly int Ticket;
		public readonly int CompleteLevelsCount;
		public readonly int SuccessiveDay;
		public readonly DateTime OnEnterTime;
		public readonly DateTime FirstEnterTime;
		
		public SaveData(int levelsCount, int ticket, int successiveDay, DateTime onEnterTime, DateTime firstEnterTime)
		{
			Ticket = ticket;
			OnEnterTime = onEnterTime;
			FirstEnterTime = firstEnterTime;
			SuccessiveDay = successiveDay;
			CompleteLevelsCount = levelsCount;
		}
	}
	
	public class SavePrefs : MonoBehaviour
	{
		private const string TICKET = "Ticket";
		private const string LEVELS = "CompleteLevelsCount";
		private const string FIRST_ENTER_TIME = "FirstEnterTime";
		private const string SUCCESSIVE_DAY = "SuccessiveDay";

		private const string SAVED_GAME_EXISTS = "SavedGameExists";

		public SaveData SaveData;

		private void Awake()
		{
			if (PlayerPrefs.HasKey(SAVED_GAME_EXISTS) && PlayerPrefs.GetInt(SAVED_GAME_EXISTS) == 1)
			{
				SaveData = Load();
			}
			else
			{
				SaveData = new SaveData(0, 100,0, DateTime.Now, DateTime.Now);
			}
		}

		private static void Save(SaveData saveData)
		{
			PlayerPrefs.SetInt(LEVELS, saveData.CompleteLevelsCount);
			PlayerPrefs.SetInt(TICKET, saveData.Ticket);
			PlayerPrefs.SetInt(SUCCESSIVE_DAY, saveData.SuccessiveDay);
			PlayerPrefs.SetString(FIRST_ENTER_TIME, saveData.FirstEnterTime.ToShortDateString());

			PlayerPrefs.SetInt(SAVED_GAME_EXISTS, 1);
		}

		private static SaveData Load()
		{
			int levels = PlayerPrefs.GetInt(LEVELS);
			int ticket = PlayerPrefs.GetInt(TICKET);
			int day = PlayerPrefs.GetInt(SUCCESSIVE_DAY);
			string firstEnterTime = PlayerPrefs.GetString(FIRST_ENTER_TIME);

			return new SaveData(levels, ticket, day, DateTime.Now,  DateTime.Parse(firstEnterTime));
		}

		private void OnApplicationQuit()
		{
			Save(SaveData);
		}
	}
}