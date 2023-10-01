using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonImageSwitcher : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;
    public Sprite normalSprite;
    public Sprite hoverSprite;
    public Sprite clickSprite;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = clickSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
    }
}
