using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;

    private Slider _healthSlider;

    private void Awake()
    {
        _health.Changed += OnChanged;

        _healthSlider = GetComponent<Slider>();
        _healthSlider.maxValue = _health.HealthAmount;
    }

    private void OnChanged(int health)
    {
        _healthSlider.value = health;
    }
}
