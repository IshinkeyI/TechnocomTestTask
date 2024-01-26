using TMPro;
using Events;
using UnityEngine;

namespace Managers
{
	public class TicketManager : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI ticketCountText;

		private SavePrefs.SavePrefs _savePrefs;
		
		private void Start()
		{
			_savePrefs = FindObjectOfType<SavePrefs.SavePrefs>();
			ChangeTicketCount();
		}

		private void OnEnable()
		{
			StaticEvents.GetReward += ChangeTicketCount;
		}

		private void OnDisable()
		{
			StaticEvents.GetReward -= ChangeTicketCount;
		}

		private void ChangeTicketCount()
		{
			ticketCountText.text = $"{_savePrefs.SaveData.Ticket}";
		}
	}
}