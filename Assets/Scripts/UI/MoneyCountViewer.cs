using UnityEngine;
using UnityEngine.UI;

public class MoneyCountViewer : MonoBehaviour
{
    [SerializeField] private Text _textField;

    private void Start()
    {
        GameVariables.Instance.ChangeMoneyCountEvent += OnValueChanged;
        _textField.text = GameVariables.Instance.Money.ToString();
    }

    private void OnDestroy()
    {
        GameVariables.Instance.ChangeMoneyCountEvent -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _textField.text = value.ToString();
    }
}
