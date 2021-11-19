using UnityEngine;
using UnityEngine.UI;

public class WorkerDataViewer : MonoBehaviour
{
    [SerializeField] private Worker _worker;
    [SerializeField] private Slider _energySlider;
    [SerializeField] private Slider _stressSlider;

    private void Start()
    {
        _worker.ChangeEnergyEvent += OnChangeEnergyCount;
        _worker.ChangeStressEvent += OnChangeStressCount;
    }
    
    private void OnDestroy()
    {
        _worker.ChangeEnergyEvent -= OnChangeEnergyCount;
        _worker.ChangeStressEvent -= OnChangeStressCount;
    }

    private void OnChangeEnergyCount(float currentEnergyCount)
    {
        _energySlider.value = currentEnergyCount;
    }
    
    private void OnChangeStressCount(float stressEnergyCount)
    {
        _stressSlider.value = stressEnergyCount;
    }
}
