using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Sector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    public Vector2 _sectorRange;
    public float Angle { get; private set; }
    public int Slot { get; private set; }

    public void Setup(int multiplier, Vector2 range, float angle, Color color) 
    {
        Angle = angle;
        _sectorRange = range;
        Slot = multiplier;
        _text.text = "x" + Slot.ToString();
        GetComponent<Image>().color = color;
    }

    public bool IsInRange(float angle) 
    {
        return _sectorRange.x < angle && angle <= _sectorRange.y;
    }
}
