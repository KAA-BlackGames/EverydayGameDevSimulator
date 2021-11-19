using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _startScreen;
    [SerializeField] private GameObject _overlay;
    [SerializeField] private GameObject _winPopup;
    [SerializeField] private GameObject _losePopup;

    private void Start()
    {
        GameController.Instance.GameStartEvent += OnGameStart;
        GameController.Instance.GameOverEvent += OnGameOver;
        
        _startScreen.SetActive(true);
    }
    
    private void OnDestroy()
    {
        GameController.Instance.GameStartEvent -= OnGameStart;
        GameController.Instance.GameOverEvent -= OnGameOver;
    }
    
    private void OnGameStart()
    {
        _overlay.SetActive(true);
    }
    
    private void OnGameOver(bool isWin)
    {
        _overlay.SetActive(false);
        
        if (isWin)
            _winPopup.SetActive(true);
        else
            _losePopup.SetActive(true);
    }
}
