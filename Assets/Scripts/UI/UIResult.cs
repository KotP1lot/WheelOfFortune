using TMPro;
using UnityEngine;

public class UIResult : MonoBehaviour
{
    [SerializeField]
    private SlotManager _slotManager;
    [SerializeField]
    private GameObject _menu;
    [SerializeField]
    private TextMeshProUGUI _lable;
    [SerializeField]
    private TextMeshProUGUI _result;

    private void ShowResult(int result) 
    {
        _menu.SetActive(true);
        _lable.text = result == 0 ? "TRY AGAIN!" : "WIN";
        _result.text = result == 0? "" : result.ToString();
    }

    private void OnEnable()
    {
        _slotManager.OnResult += ShowResult;
    }
    private void OnDisable()
    {
        _slotManager.OnResult -= ShowResult;
    }
}
