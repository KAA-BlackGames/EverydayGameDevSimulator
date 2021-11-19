using System;
using UnityEngine;

public class ReleasedProduct : MonoBehaviour
{
    public event Action<float> ChangeProgressEvent;
    
    private float _productSize;
    private float _currentProjectPoints;
    private float _progress;
    
    public void SetProjectSize(int value)
    {
        _productSize = value;
        _currentProjectPoints = 0;
        
        CalculateProgress();
    }
    
    public void AddProjectPoints(float value)
    {
        _currentProjectPoints += value;
        _currentProjectPoints = Mathf.Clamp(_currentProjectPoints, 0, _productSize);
        CalculateProgress();
    }

    private void CalculateProgress()
    {
        _progress = _currentProjectPoints / _productSize;
        ChangeProgressEvent?.Invoke(_progress);
        
        if (_progress == 1)
            GameController.Instance.GameOver(true);
    }
}
