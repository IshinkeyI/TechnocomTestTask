using Events;
using UnityEngine;
using System.Collections.Generic;

namespace UI.LevelsView
{
	public class LevelsGroup : MonoBehaviour
	{
		[SerializeField] private List<LevelButton> levelButtons;

		private SavePrefs.SavePrefs _savePrefs;		
		
		private void OnEnable()
		{
			StaticEvents.LevelComplete += Fill;
		}

		private void OnDisable()
		{
			StaticEvents.LevelComplete -= Fill;
		}

		private void Start()
		{
			_savePrefs ??= FindObjectOfType<SavePrefs.SavePrefs>();
			Fill();
		}

		private void Fill()
		{
			var d = _savePrefs.SaveData;
			for (int i = 0; i < levelButtons.Count; i++)
			{
				levelButtons[i].SetLevelNumber(i);
				Debug.Log($"level № {i} is {d.CompleteLevelsCount == i}");
				if (d.CompleteLevelsCount <= i)
				{
					levelButtons[i].UnlockLevel();
				}
				else
				{
					levelButtons[i].LockLevel();
				}
			}
		}
	}
}