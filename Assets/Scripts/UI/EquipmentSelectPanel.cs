using Ship;
using UnityEngine;

namespace UI
{
    public abstract class EquipmentSelectPanel : MonoBehaviour
    {
        [SerializeField] private RectTransform _rectTransform;

        public CandidateId CandidateId { get; private set; }
        public int SlotIndex { get; private set; }
        
        public void Show(int slotIndex, Transform anchor, CandidateId candidateId)
        {
            gameObject.SetActive(true);
            _rectTransform.position = anchor.position;
            CandidateId = candidateId;
            SlotIndex = slotIndex;
        }

        public void Hide() => gameObject.SetActive(false);
    }
}