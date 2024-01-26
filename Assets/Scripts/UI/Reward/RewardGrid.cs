using System;
using System.Linq;
using Events;
using SavePrefs;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Reward
{
	public class RewardGrid : AGrid
	{
		[SerializeField] private UITab congratsView;
		
		private SOReward _soReward;
		private SavePrefs.SavePrefs _savePrefs;

		private bool _isAnyoneRewardGivable; 

		private void OnEnable()
		{
			StaticEvents.GetReward += Fill;
			
			_savePrefs ??= FindObjectOfType<SavePrefs.SavePrefs>();
			_soReward ??= Resources.Load<SOReward>("SO/Reward");
			
			Fill();
		}

		private void OnDisable()
		{
			StaticEvents.GetReward -= Fill;
		}

		private void Update()
		{
			if (_soReward.Rewards.Any(r => _savePrefs.SaveData.SuccessiveDay == r.dayNumber - 1 &&
			                               DateTime.Now.Minute - _savePrefs.SaveData.FirstEnterTime.Minute -
			                               (r.dayNumber - 1) == 0))
			{
				Debug.Log("Givable");
			}
		}

		public override void Fill()
		{
			Clear();
			_isAnyoneRewardGivable = false;
			Debug.Log("Clear");
			
			foreach (var reward in _soReward.Rewards)
			{
				if (reward.dayNumber == 7)
				{
					congratsView.Open();
					GetReward(reward, null);

					var d = _savePrefs.SaveData;
					d = new SaveData(d.CompleteLevelsCount, d.Ticket, 0, d.OnEnterTime, DateTime.Now);
					_savePrefs.SaveData = d;
					return;
				}
				InitGridElement(reward);
			}

			if (_savePrefs.SaveData.OnEnterTime.Minute - _savePrefs.SaveData.FirstEnterTime.Minute <= 1) return;
			
			var data = _savePrefs.SaveData;
			data = new SaveData(data.CompleteLevelsCount, data.Ticket, 0, data.OnEnterTime, DateTime.Now);
			_savePrefs.SaveData = data;
		}

		private void InitGridElement(Reward reward)
		{
			var instantContentElem = InstantiateElement();
			var gridElement = instantContentElem.GetComponent<RewardGridElement>();

			gridElement.DayText.text = $"DAY {reward.dayNumber}";
			gridElement.CountText.text = $"x{reward.ticketCount}";

			if (_isAnyoneRewardGivable)
			{
				gridElement.DayActive();
				Debug.Log($"NOT givable {reward.dayNumber}");
				return;
			}

			_isAnyoneRewardGivable = _savePrefs.SaveData.SuccessiveDay == reward.dayNumber - 1 &&
			                         DateTime.Now.Minute - _savePrefs.SaveData.FirstEnterTime.Minute -
			                         (reward.dayNumber - 1) == 0;

			if (_isAnyoneRewardGivable)
			{
				Debug.Log($"givable {reward.dayNumber}");
				gridElement.GetButton.onClick.AddListener(() => GetReward(reward, gridElement.GetButton));
			}

			if (_savePrefs.SaveData.SuccessiveDay < reward.dayNumber)
				gridElement.DayActive();
			else
				gridElement.DayComplete();
		}

		private void GetReward(Reward reward, Button button)
		{
			var data = _savePrefs.SaveData;
			data = new SaveData(data.CompleteLevelsCount, data.Ticket + reward.ticketCount,
				data.SuccessiveDay + 1, DateTime.Now, data.FirstEnterTime);
			_savePrefs.SaveData = data;

			if (button != null)
				button.onClick.RemoveAllListeners();
			
			StaticEvents.OnGetReward();
		}
	}
}