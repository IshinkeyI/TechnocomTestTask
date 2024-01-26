using System;

namespace Events
{
	public static class StaticEvents
	{
		public static Action GetReward;
		public static Action LevelComplete;

		public static void OnGetReward()
		{
			GetReward?.Invoke();
		}
		
		public static void OnLevelComplete()
		{
			LevelComplete?.Invoke();
		}
	}
}