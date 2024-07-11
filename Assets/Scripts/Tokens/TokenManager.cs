using System.Collections.Generic;
using UnityEngine;

public class TokenManager : MonoBehaviour
{
    [SerializeField] private List<Token> _tokens;
    [SerializeField] private List<Slot> _slots;
    [SerializeField] private Money _money;
    private int _currTokenValue;
    private void Start()
    {
        OnTokenClickHandler(_tokens[2]);
    }
    private void OnTokenClickHandler(Token target)
    {
        _currTokenValue = target.Value;
        foreach (var token in _tokens)
        {
            token.SetActive(token == target);
        }
    }
    private void OnSlotClickHandler(Slot target)
    {
        if (_currTokenValue == 0) _money.Add(target.ReturnBet());
        else
        {
            if (_money.Amount < _currTokenValue) return;
            target.PlaceBet(_currTokenValue);
            _money.Spend(_currTokenValue);
        }
    }
    public void ClearAllSlots() 
    {
        foreach (var slot in _slots)
            _money.Add(slot.ReturnBet());
    }
    private void OnEnable()
    {
        foreach (var token in _tokens)
            token.OnTokenClick += OnTokenClickHandler;
        foreach (var slot in _slots)
            slot.OnSlotClick += OnSlotClickHandler;
    }
    private void OnDisable()
    {
        foreach (var token in _tokens)
            token.OnTokenClick -= OnTokenClickHandler;
        foreach (var slot in _slots)
            slot.OnSlotClick -= OnSlotClickHandler;
    }
}
