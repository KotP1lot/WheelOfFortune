using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    [field: SerializeField]
    public int SlotIndex { get; private set; }
    public int Bet { get; private set; }
    public event Action<Slot> OnSlotClick;

    [SerializeField] TextMeshProUGUI _betTxt;

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSlotClick?.Invoke(this);
    }

    public void PlaceBet(int bet)
    {
        Bet += bet;
        UpdateBetTxt();
    }

    public int ReturnBet()
    {
        int value = Bet;
        Bet = 0;
        UpdateBetTxt();
        return value;
    }
    private void UpdateBetTxt()
    {
        _betTxt.text = Bet.ToString();
    }

    public int GetPrize() 
    {
        int value = ReturnBet();
        return value * SlotIndex + value;
    }
}
