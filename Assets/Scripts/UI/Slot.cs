using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Slot : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [field: SerializeField] public Button SelectButton { get; private set; }
        [field: SerializeField] public RectTransform[] SelectPanelAnchors { get; private set; }
        
        public Transform Anchor => SelectPanelAnchors[0];
        public int Index { get; private set; }
        
        public void Init(int index, Sprite icon = null)
        {
            Index = index;
            SetIcon(icon);
        }

        public void SetIcon(Sprite icon)
        {
            _icon.sprite = icon;
        }
    }
}