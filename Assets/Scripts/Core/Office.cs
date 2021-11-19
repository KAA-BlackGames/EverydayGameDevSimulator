using System.Collections.Generic;
using UnityEngine;

public class Office : MonoBehaviour
{
    [SerializeField] private ReleasedProduct releasedProduct;
    [SerializeField] private List<Worker> _workers;

    private void Start()
    {
        GameController.Instance.GameStartEvent += OnGameStart;
        GameController.Instance.GameOverEvent += OnGameOver;
        
        foreach (var worker in _workers)
        {
            worker.WorkerQuitEvent += OnWorkerQuit;
        }
    }

    private void OnDestroy()
    {
        GameController.Instance.GameStartEvent -= OnGameStart;
        GameController.Instance.GameOverEvent -= OnGameOver;
        
        foreach (var worker in _workers)
        {
            worker.WorkerQuitEvent -= OnWorkerQuit;
        }
    }
    
    private void OnGameStart()
    {
        releasedProduct.SetProjectSize(100 * GameVariables.Instance.LevelNumber);
        foreach (var worker in _workers)
        {
            worker.StartWork(releasedProduct);
        }
    }
    
    private void OnGameOver(bool isWin)
    {
        foreach (var worker in _workers)
        {
            worker.StopWork();
        }
    }

    private void OnWorkerQuit(Worker worker)
    {
        worker.WorkerQuitEvent -= OnWorkerQuit;
        _workers.Remove(worker);

        if (_workers.Count < 1)
            GameController.Instance.GameOver(false);
    }
}
