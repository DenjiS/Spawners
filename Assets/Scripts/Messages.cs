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
        "Вот и всё.",
        "Ты убил всех жителей деревни.",
        "Здесь больше не будет слышно радостного щенячьего лая.",
        "Не будет радостей и горестей любви, не будет дружбы.",
        "Стало так мирно и спокойно.",
        "Только реки крови тихо журчат у тебя под ногами."
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
                StartCoroutine(ShowMessage("Зачем ты убил собачку?"));
                break;

            case 5:
                StartCoroutine(ShowMessage("Они же просто хотят поиграться"));
                break;

            case 10:
                StartCoroutine(ShowMessage("Уже 10 жестоких убийств на твоём счёту"));
                break;

            case 15:
                StartCoroutine(ShowMessage("Остановись, прошу"));
                break;

            case 20:
                StartCoroutine(ShowMessage("Ты поступаешь так со всеми, кто пытается с тобой дружить?"));
                break;

            case 25:
                StartCoroutine(ShowMessage("Зачем тебе всё это?"));
                break;

            case 30:
                StartCoroutine(ShowMessage("Просто закрой игру, это будет самым правильным решением"));
                break;

            case 35:
                StartCoroutine(ShowMessage("Они же ещё щеночки!"));
                break;

            case 40:
                StartCoroutine(ShowMessage("Совсем молодые и неопытные!"));
                break;

            case 45:
                StartCoroutine(ShowMessage("Разве ты не слышишь как им больно умирать?"));
                break;

            case 50:
                StartCoroutine(ShowMessage("Ты перерезал половину деревни"));
                break;

            case 55:
                StartCoroutine(ShowMessage("Сомневаюсь, что они когда-нибудь оправится от этой потери"));
                break;

            case 60:
                StartCoroutine(ShowMessage("Ты чудовище!"));
                break;

            case 65:
                StartCoroutine(ShowMessage("Сомневаюсь, что они когда-нибудь оправится от этой потери"));
                break;

            case 70:
                StartCoroutine(ShowMessage("Мне начинает казаться, что тебе просто интересно, чем всё закончится"));
                break;

            case 75:
                StartCoroutine(ShowMessage("Ничем хорошим"));
                break;

            case 80:
                StartCoroutine(ShowMessage("Оно того не стоит!"));
                break;

            case 85:
                StartCoroutine(ShowMessage("Оставь хоть кого-нибудь"));
                break;

            case 90:
                StartCoroutine(ShowMessage("Ты почти достиг своей бессердечной цели, ты доволен?"));
                break;

            case 95:
                StartCoroutine(ShowMessage("Монстр."));
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
