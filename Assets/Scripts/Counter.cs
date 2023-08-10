using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Counter : MonoBehaviour
{
    [SerializeField] private FirstPersonController _controller;

    private TextMeshProUGUI _text;
    private string _textBeforeCount = "Убийств: ";

    private int _count = 0;

    public event Action<int> Changed;

    private void Awake()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.text = _textBeforeCount + _count;
    }

    public void Increment()
    {
        _text.SetText(_textBeforeCount + ++_count);
        Changed?.Invoke(_count);

        if (_count >= 100)
            _controller.enabled = false;
    }
}
