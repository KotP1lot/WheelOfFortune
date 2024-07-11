using System;
using System.Collections.Generic;
using UnityEngine;
public class Wheel : MonoBehaviour
{
    [SerializeField]
    private Sector _sectorPrefabs;
    [SerializeField]
    private List<Color> _colors;
    private int angleStep = 20;
    private List<Sector> _sectors = new();

    private Rigidbody2D _rb;
    private bool _isSpinning;
    private bool _isReady;
    private float _speed;

    public event Action<int> OnWheelSpinComplete;


    private void Start()
    {
        SetupSectors();
    }
    private void SetupSectors()
    {
        _isSpinning = false;
        _isReady = true;
        _rb = GetComponent<Rigidbody2D>();
        int segments = 360 / angleStep;

        for (int i = 0; i < segments; i++)
        {
            Sector sector = Instantiate(_sectorPrefabs, transform);
            float angle = angleStep * i;
            sector.transform.rotation = Quaternion.Euler(0, 0, -angle);
            int multiplier;
            if (i == 0) multiplier = 5;
            else if (i == 1 || i == 17 || i == 4 || i == 8 || i == 10 || i == 13) multiplier = 2;
            else if (i == 9 || i == 5 || i == 14) multiplier = 3;
            else multiplier = 1;
            sector.Setup(multiplier, new(angle - angleStep/2, angle + angleStep/2), angle, _colors[i % 2 == 0 ? 0 : 1]);
            sector.transform.SetAsFirstSibling();
            _sectors.Add(sector);
        }
    }
    private void Update()
    {
        if (_isSpinning)
        {
            if (_rb.angularVelocity < 0.1f)
            {
                _isSpinning = false;
                Sector currSector = GetSector();
                transform.rotation = Quaternion.Euler(0, 0, currSector.Angle);
                _rb.angularVelocity = 0;
                OnWheelSpinComplete?.Invoke(currSector.Slot);
                Debug.Log(currSector.Slot);
            }
        }
    }
    private Sector GetSector()
    {
        return _sectors.Find(x => x.IsInRange(transform.rotation.eulerAngles.z));
    }
    public void SetReady() => _isReady = true;
    public void StartSpinning()
    {
        if (_isReady)
        {
            _isReady = false;
            _isSpinning = true;
            _speed = UnityEngine.Random.Range(10, 360);
            _rb.AddTorque(_speed, ForceMode2D.Impulse);
        }
    }
}
