using System.Collections;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class CurtainUI : MonoBehaviour
    {
        private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show()
        {
            _canvasGroup.alpha = 1;
            gameObject.SetActive(true);
        }

        public void Hide() => StartCoroutine(FadeOut());

        private IEnumerator FadeOut()
        {
            var waiter = new WaitForSeconds(0.2f);
            var step = 0.1f;
            
            while(_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= step;
                yield return waiter;
            }
            
            gameObject.SetActive(false);
        }
    }
}