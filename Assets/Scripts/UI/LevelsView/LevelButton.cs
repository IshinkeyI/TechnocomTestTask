using Managers;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.LevelsView
{
	public class LevelButton : MonoBehaviour
	{
		[SerializeField] private GameObject textGameObject;
		[SerializeField] private Image lockImage;
		[SerializeField] private Button button;
		
		private TextMeshProUGUI _levelNumberText;
		private GameManager _gameManager;
		private int _currentLevelNumber;

		private void Awake()
		{
			_levelNumberText = textGameObject.GetComponent<TextMeshProUGUI>();
			_gameManager = FindObjectOfType<GameManager>();
		}

		public void SetLevelNumber(int levelNumber)
		{
			_levelNumberText.text = $"{levelNumber + 1}";
			_currentLevelNumber = levelNumber;
		}

		public void LockLevel()
		{
			button.onClick.RemoveAllListeners();
			lockImage.enabled = true;
			textGameObject.SetActive(false);
		}

		public void UnlockLevel()
		{
			button.onClick.AddListener(StartLevel);
			lockImage.enabled = false;
			textGameObject.SetActive(true);
		}

		private void StartLevel()
		{
			_gameManager.StartGame(_currentLevelNumber);
			LockLevel();
		}
	}
}