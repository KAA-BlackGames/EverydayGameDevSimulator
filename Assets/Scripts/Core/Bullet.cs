using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _energyChange;
    [SerializeField] private int _stressChange;

    public int EnergyChange => _energyChange;
    public int StressChange => _stressChange;
}