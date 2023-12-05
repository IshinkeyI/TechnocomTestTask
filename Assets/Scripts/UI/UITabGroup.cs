using JetBrains.Annotations;
using UnityEngine;

namespace UI
{
	public class UITabGroup : MonoBehaviour
	{
		[Header("Группа вкладок, где может быть открыта только одна")]

		[Header("Автоматически открывать вкладку нажатием, если не предусмотрено сворачивание")]
		[SerializeField][CanBeNull] private UIButton firstClicked;

		public UITab OpenedTab { get; private set; }

		private void Start()
		{
			OpenedTab = null;   
			if (firstClicked)
				firstClicked.button.onClick.Invoke();
		}

		public void OpenTab(UITab tab)
		{
			if (tab == OpenedTab)
			{
				if (tab.IsOpened && tab.closeOnSecondClick)
					CloseTab(tab);
				return;
			}
        
			CloseTab(OpenedTab);
        
			OpenedTab = tab;
			if (OpenedTab)
				OpenedTab.Open();
		}

		public void CloseTab(UITab tab)
		{
			if (tab)
				tab.Close();
			OpenedTab = null;
		}

		public void CloseOpenedTab()
		{
			CloseTab(OpenedTab);
		}
	}
}