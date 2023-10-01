using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    public Image buttonImage;
    public Sprite normalSprite;
    public Sprite hoverSprite;
    public Sprite clickSprite;

    public Vector2 normalSize;
    public Vector2 hoverSize;
    public Vector2 clickSize;

    private void Start()
    {
        buttonImage = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
        buttonImage.rectTransform.sizeDelta = hoverSize;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.sprite = normalSprite;
        buttonImage.rectTransform.sizeDelta = normalSize;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonImage.sprite = clickSprite;
        buttonImage.rectTransform.sizeDelta = clickSize;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonImage.sprite = hoverSprite;
        buttonImage.rectTransform.sizeDelta = hoverSize;
    }
}
