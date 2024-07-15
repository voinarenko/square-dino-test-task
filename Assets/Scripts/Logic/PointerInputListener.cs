using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Logic
{
    public class PointerInputListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
    {
        public event Action Clicked;

        [SerializeField] private TextMeshProUGUI _message;
        
        public void OnPointerClick(PointerEventData eventData) =>
            Clicked?.Invoke();

        public void OnPointerDown(PointerEventData eventData) { }

        public void OnPointerUp(PointerEventData eventData) { }

        public void HideMessage() =>
            _message.gameObject.SetActive(false);
    }
}