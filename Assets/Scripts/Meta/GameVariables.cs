using System;
using UnityEngine;

public class GameVariables : MonoBehaviour
{
    public static GameVariables Instance {get; private set; }
    public event Action<int> ChangeLevelNumberEvent;
    public event Action<int> ChangeMoneyCountEvent;

    private int _levelNumber;
    private int _money;

    public int LevelNumber => _levelNumber;
    public int Money => _money;
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        LoadData();
    }

    private void LoadData()
    {
        _levelNumber = 1;
        ChangeLevelNumberEvent?.Invoke(_levelNumber);
        _money = 10000;
        ChangeMoneyCountEvent?.Invoke(_money);
    }

    public void AddMoney(int value)
    {
        if (value < 0)
            return;

        _money += value;
        ChangeMoneyCountEvent?.Invoke(_money);
    }

    public bool TrySpendMoney(int value)
    {
        if (value < 0)
            return false;

        if (_money < value)
            return false;

        _money -= value;
        ChangeMoneyCountEvent?.Invoke(_money);
        return true;
    }

    public void NextLevel()
    {
        _levelNumber++;
        ChangeLevelNumberEvent?.Invoke(_levelNumber);
    }
}
