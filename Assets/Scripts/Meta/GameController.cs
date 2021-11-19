using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance {get; private set; }
    public event Action GameStartEvent;
    public event Action<bool> GameOverEvent;

    private bool _isGameStart;

    public bool IsGameStart => _isGameStart;

    private void Awake()
    {
        Instance = this;
    }

    public void GameStart()
    {
        if (_isGameStart)
            return;
        
        GameStartEvent?.Invoke();
        _isGameStart = true;
    }

    public void GameOver(bool isWin)
    {
        if (!_isGameStart)
            return;
        
        GameOverEvent?.Invoke(isWin);
        _isGameStart = false;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel()
    {
        GameVariables.Instance.NextLevel();
        GameStart();
    }
}
