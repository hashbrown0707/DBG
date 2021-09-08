using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CardSystem
{
    public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        private ICard card;
        private RectTransform rectTransform;
        private Vector3 offPos;
        private Vector3 arragedPos;

        private bool isDragging;

        void Start()
        {
            //card = GetComponent<Card>();
            card = GetComponent(typeof(ICard)) as ICard;
            rectTransform = GetComponent<RectTransform>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            isDragging = true;

            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(rectTransform, Input.mousePosition, eventData.enterEventCamera, out arragedPos))
                offPos = transform.position - arragedPos;
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = offPos + Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            isDragging = false;

            //找出是否raycast到handPanel(card的母物件)
            List<RaycastResult> raycastResults = new List<RaycastResult>();
            GameObject parent = this.gameObject.transform.parent.gameObject;
            EventSystem.current.RaycastAll(eventData, raycastResults);

            foreach (var item in raycastResults)
            {
                if(item.gameObject == parent)
                {
                    transform.position = offPos + arragedPos;
                    return;
                }
            }

            //沒raycast到handPanel
            transform.position = offPos + Input.mousePosition;
            ////////
            card.OnUse((card as Card).player);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if(!isDragging)
                card.OnHover();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!isDragging)
                card.OnHoverExit();
        }
    }
}
