using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class Token : MonoBehaviour, IPointerClickHandler
{
    [field: SerializeField]
    public int Value { get; private set; }
    public event Action<Token> OnTokenClick;
    private RectTransform _rect;
    private void Start()
    {
        _rect = GetComponent<RectTransform>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        OnTokenClick?.Invoke(this);
    }
    public void SetActive(bool isActive)
    {
        float size = isActive ? 400 : 350;
        _rect.sizeDelta = new Vector2(size, size);
    }
}
