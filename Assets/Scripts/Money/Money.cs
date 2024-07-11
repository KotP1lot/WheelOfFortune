using System;
using UnityEngine;

public class Money : MonoBehaviour
{
    public event Action OnMoneyChanged;
    public int Amount { get; private set; }
    private void Start()
    {
        SetMoney(200000);
    }

    public void Spend(int amount) 
    {
        Amount -= amount;
        OnMoneyChanged?.Invoke();
    }

    public void Add(int amount) 
    {
        Amount += amount;
        OnMoneyChanged?.Invoke();
    }

    public void SetMoney(int amount) 
    {
        Amount = amount;
        OnMoneyChanged?.Invoke();
    }
}
