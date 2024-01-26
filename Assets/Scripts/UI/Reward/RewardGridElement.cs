using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Reward
{
    public class RewardGridElement : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dayText;
        [SerializeField] private TextMeshProUGUI countText;
        [SerializeField] private Button getButton;

        [Space] 
        [SerializeField] private Sprite completeSprite;
        [SerializeField] private Sprite ticketSprite;
        [SerializeField] private Image image;

        private RectTransform _rectTransform;
        
        #region Properties
        public Button GetButton => getButton;

        public TextMeshProUGUI DayText => dayText;

        public TextMeshProUGUI CountText => countText;
        #endregion

        private void Awake()
        {
            _rectTransform = image.GetComponent<RectTransform>();
        }

        public void DayComplete()
        {
            image.sprite = completeSprite;
            _rectTransform.sizeDelta = new Vector2(75,75);
            countText.enabled = false;
        }

        public void DayActive()
        {
            image.sprite = ticketSprite;
            _rectTransform.sizeDelta = new Vector2(125,125);
            countText.enabled = true;
        }
    }
}
