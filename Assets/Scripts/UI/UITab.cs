using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

namespace UI
{
	public class UITab : MonoBehaviour
	{
		[Header("Группа вкладок.")]
		[SerializeField] private UITabGroup group;

		[Header("Контент")]
		[SerializeField] private GameObject contentPanel;

		[Header("Кнопки открытия.")] 
		[SerializeField] private List<UIButton> openButtons;
		[SerializeField] private UnityEvent onOpen;

		[Header("Кнопки закрытия.")]
		[SerializeField] private List<UIButton> exitButtons;
		[SerializeField] private UnityEvent onExit;
		
		[Header("Закрывать вкладку на повторный клик")]
		public bool closeOnSecondClick;
		public bool IsOpened { get; private set; }

		private void Awake()
		{
			foreach (var openButton in openButtons)
			{
				openButton.button.onClick.AddListener(() => { group.OpenTab(this); });
				openButton.SetInteractable(false);
			}

			foreach (var exitButton in exitButtons)
				exitButton.button.onClick.AddListener(() => group.CloseTab(this));
		}
		
		private void SetContentPanelActive(bool active)
		{
			if (contentPanel != null)
				contentPanel.SetActive(active);

			foreach (UIButton exitButton in exitButtons)
				exitButton.gameObject.SetActive(active);

			foreach (UIButton openButton in openButtons)
				openButton.SetInteractable(active);
		}

		public void Open()
		{ 
			if(IsOpened)
				return;
			IsOpened = true;
			onOpen?.Invoke();
        
			SetContentPanelActive(true);
		}

		public void Close()
		{
			onExit?.Invoke();
			IsOpened = false;

			SetContentPanelActive(false);
		}
	}
}