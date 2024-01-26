using System;
using System.Collections.Generic;
using UnityEngine;

namespace UI.Reward
{
	[CreateAssetMenu(fileName = "Reward", menuName = "Rewards/RewardElement")]
	public class SOReward : ScriptableObject
	{
		[SerializeField] private List<Reward> rewards;

		public List<Reward> Rewards => rewards;
	}

	[Serializable]
	public struct Reward
	{
		public int dayNumber;
		public int ticketCount;
	} 
}