using UnityEngine;
using UnityEngine.UI;

public class LevelNumberViewer : MonoBehaviour
{
    [SerializeField] private Text _textField;

    private void Start()
    {
        GameVariables.Instance.ChangeLevelNumberEvent += OnValueChanged;
        _textField.text = GameVariables.Instance.LevelNumber.ToString();
    }

    private void OnDestroy()
    {
        GameVariables.Instance.ChangeLevelNumberEvent -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _textField.text = value.ToString();
    }
}
