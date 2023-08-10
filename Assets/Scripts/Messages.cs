using System.Collections;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Messages : MonoBehaviour
{
    [SerializeField] private GameLoader _loader;
    [SerializeField] private float _durationOfAppearance;
    [SerializeField] private string _headerText;

    private string[] _finalMessages = new string[]
    {
        "��� � ��.",
        "�� ���� ���� ������� �������.",
        "����� ������ �� ����� ������ ���������� ��������� ���.",
        "�� ����� �������� � �������� �����, �� ����� ������.",
        "����� ��� ����� � ��������.",
        "������ ���� ����� ���� ������ � ���� ��� ������."
    };

    private TextMeshProUGUI _textTMP;
    private Counter _counter;

    private WaitForSeconds _disappearDelay;

    private void Awake()
    {
        _textTMP = GetComponent<TextMeshProUGUI>();
        _textTMP.text = string.Empty;

        _counter = FindAnyObjectByType<Counter>();

        _disappearDelay = new WaitForSeconds(_durationOfAppearance);
    }

    private void OnEnable()
    {
        _counter.Changed += OnChanged;
    }

    private void OnDisable()
    {
        _counter.Changed -= OnChanged;
    }

    private void OnChanged(int kills)
    {
        switch (kills)
        {
            case 1:
                StartCoroutine(ShowMessage("����� �� ���� �������?"));
                break;

            case 5:
                StartCoroutine(ShowMessage("��� �� ������ ����� ����������"));
                break;

            case 10:
                StartCoroutine(ShowMessage("��� 10 �������� ������� �� ���� �����"));
                break;

            case 15:
                StartCoroutine(ShowMessage("����������, �����"));
                break;

            case 20:
                StartCoroutine(ShowMessage("�� ���������� ��� �� �����, ��� �������� � ����� �������?"));
                break;

            case 25:
                StartCoroutine(ShowMessage("����� ���� �� ���?"));
                break;

            case 30:
                StartCoroutine(ShowMessage("������ ������ ����, ��� ����� ����� ���������� ��������"));
                break;

            case 35:
                StartCoroutine(ShowMessage("��� �� ��� �������!"));
                break;

            case 40:
                StartCoroutine(ShowMessage("������ ������� � ���������!"));
                break;

            case 45:
                StartCoroutine(ShowMessage("����� �� �� ������� ��� �� ������ �������?"));
                break;

            case 50:
                StartCoroutine(ShowMessage("�� ��������� �������� �������"));
                break;

            case 55:
                StartCoroutine(ShowMessage("����������, ��� ��� �����-������ ��������� �� ���� ������"));
                break;

            case 60:
                StartCoroutine(ShowMessage("�� ��������!"));
                break;

            case 65:
                StartCoroutine(ShowMessage("����������, ��� ��� �����-������ ��������� �� ���� ������"));
                break;

            case 70:
                StartCoroutine(ShowMessage("��� �������� ��������, ��� ���� ������ ���������, ��� �� ����������"));
                break;

            case 75:
                StartCoroutine(ShowMessage("����� �������"));
                break;

            case 80:
                StartCoroutine(ShowMessage("��� ���� �� �����!"));
                break;

            case 85:
                StartCoroutine(ShowMessage("������ ���� ����-������"));
                break;

            case 90:
                StartCoroutine(ShowMessage("�� ����� ������ ����� ������������ ����, �� �������?"));
                break;

            case 95:
                StartCoroutine(ShowMessage("������."));
                break;

            case 100:
                StartCoroutine(ShowFinalMessages());
                break;
        }
    }

    private IEnumerator ShowMessage(string message)
    {
        _textTMP.text = message;
        yield return _disappearDelay;

        _textTMP.text = string.Empty;
    }

    private IEnumerator ShowFinalMessages()
    {
        foreach (string message in _finalMessages)
        {
            _textTMP.text = message;
            yield return _disappearDelay;
        }

        MenuHeaderData.Set(_headerText);
        _loader.Load();
    }
}
