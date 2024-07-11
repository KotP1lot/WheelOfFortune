using TMPro;
using UnityEngine;

public class UIMoney : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private Money _money;
    private void Awake()
    {
        _money = GetComponent<Money>();
    }
    private void UpdateTxt()
    {
        _text.text = _money.Amount.ToString();
    }
    private void OnEnable()
    {
        _money.OnMoneyChanged += UpdateTxt;
    }
    private void OnDisable()
    {
        _money.OnMoneyChanged -= UpdateTxt;
    }
}