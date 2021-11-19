using System;
using UnityEngine;

public class Worker : MonoBehaviour
{
    public event Action<float> ChangeEnergyEvent;
    public event Action<float> ChangeStressEvent;
    public event Action<Worker> WorkerQuitEvent;
    
    [SerializeField] private Transform _headPos;
    [SerializeField] private GameObject _defaultModel;
    [SerializeField] private GameObject _quitModel;
    
    [SerializeField] private float _workPower;
    [SerializeField] private float _energyRate;

    [SerializeField] private float _maxEnergy;
    [SerializeField] private float _maxStress;

    private ReleasedProduct _releasedProduct;
    private bool _isWorking;
    private float _energy;
    private float _stress;

    public Vector3 HeadPos => _headPos.position;
    public bool IsWorking => _isWorking;

    private void Start()
    {
        _energy = _maxEnergy;
        ChangeEnergyEvent?.Invoke(_energy / _maxEnergy);
        _stress = 0f;
        ChangeStressEvent?.Invoke(_stress / _maxStress);
    }

    private void Update()
    {
        if (!_isWorking)
            return;
        
        Work();
    }

    public void StartWork(ReleasedProduct releasedProduct)
    {
        _releasedProduct = releasedProduct;
        _isWorking = true;
    }
    
    public void StopWork()
    {
        _isWorking = false;
    }

    public void ChangeStress(float value)
    {
        _stress += value;
        _stress = Mathf.Clamp(_stress, 0f, _maxStress);
        ChangeStressEvent?.Invoke(_stress / _maxStress);

        if (_stress == _maxStress)
            Quit();
    }

    public void ChangeEnergy(float value)
    {
        _energy += value;
        _energy = Mathf.Clamp(_energy, 0f, _maxEnergy);
        ChangeEnergyEvent?.Invoke(_energy / _maxEnergy);

        if (_energy == 0f)
            Quit();
    }

    private void Work()
    {
        ChangeEnergy(-_energyRate * Time.deltaTime);
        _releasedProduct.AddProjectPoints(_workPower * Time.deltaTime);
    }

    private void Quit()
    {
        _isWorking = false;
        _defaultModel.SetActive(false);
        _quitModel.SetActive(true);
        WorkerQuitEvent?.Invoke(this);
    }
}
