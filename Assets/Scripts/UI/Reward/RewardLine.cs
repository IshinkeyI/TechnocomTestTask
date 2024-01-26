using System;
using Events;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Reward
{
	public class RewardLine : MonoBehaviour
	{
		[SerializeField] private Image rewardsSlider;
		[SerializeField] private TextMeshProUGUI takenRewardsCountText;

		private SavePrefs.SavePrefs _savePrefs;

		private void Start()
		{
			_savePrefs = FindObjectOfType<SavePrefs.SavePrefs>();
			ChangeRewardLine();
		}

		private void OnEnable()
		{
			StaticEvents.GetReward += ChangeRewardLine;
		}

		private void OnDisable()
		{
			StaticEvents.GetReward -= ChangeRewardLine;
		}

		private void ChangeRewardLine()
		{
			rewardsSlider.fillAmount = _savePrefs.SaveData.SuccessiveDay / 7f;
			takenRewardsCountText.text = $"{_savePrefs.SaveData.SuccessiveDay}/7";
		}
	}
}