using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    [SerializeField] private List<Slot> _slots;
    [SerializeField] private Money _money;
    [SerializeField] private Wheel _wheel;
    [SerializeField] private TextMeshProUGUI _betText;

    public event Action<int> OnResult;

    public void CheckResult(int sector)
    {
        int result = 0;
        foreach (Slot slot in _slots)
        {
            if (sector == slot.SlotIndex)
            {
                if (slot.Bet != 0)
                {
                    result = slot.GetPrize();
                    _money.Add(result);
                  
                }
            }
            else
            {
                slot.ReturnBet();
            }
        }
        OnResult?.Invoke(result);
    }
    private void UpdateTxt() 
    {
        int bet = 0;
        foreach (Slot slot in _slots) 
        {
            bet += slot.Bet;
        }
        _betText.text = "BET: " + bet.ToString();
    }
    private void OnEnable()
    {
        _wheel.OnWheelSpinComplete += CheckResult;
        foreach (Slot slot in _slots) 
        {
            slot.OnBetChanged += UpdateTxt;
        }
    }
    private void OnDisable()
    {
        _wheel.OnWheelSpinComplete -= CheckResult;
        foreach (Slot slot in _slots)
        {
            slot.OnBetChanged -= UpdateTxt;
        }
    }
}
