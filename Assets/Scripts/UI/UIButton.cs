using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public sealed class UIButton : MonoBehaviour
	{
		public Button button;
    
		[Header("Нажатое состояние кнопки")]
		[SerializeField] private Image enabledImage;
    
		[Header("Не нажатое состояние")]
		[SerializeField] private Image disabledImage;

		private void Enable()
		{
			// button.image = enabledImage;
			// enabledImage.enabled = true;
			// disabledImage.enabled = false;
		}

		private void Disable()
		{
			// button.image = disabledImage;
			// disabledImage.enabled = true;
			// enabledImage.enabled = false;
		}

		public void SetInteractable(bool isEnable)
		{
			if(isEnable)
				Enable();
			else
				Disable();
		}
	}
}