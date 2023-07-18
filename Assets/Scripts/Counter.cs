using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private string _textBeforeCount = "Убийств: ";

    private int _count = 0;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = _textBeforeCount + _count;
    }

    public void Increment()
    {
        _text.SetText(_textBeforeCount + ++_count);
    }
}
