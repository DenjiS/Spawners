using System;
using UnityEngine;

[RequireComponent(typeof(GameLoader))]
public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _healthAmount = 100;
    [SerializeField] private string _deathMessage;

    private GameLoader _loader;
    private int _currentHealth;

    public event Action<int> Changed;

    public int HealthAmount => _healthAmount;

    public void TakeDamage()
    {
        if (--_currentHealth <= 0)
        {
            MenuHeaderData.Set(_deathMessage);
            _loader.Load();
        }

        Changed?.Invoke(_currentHealth);
    }

    private void Awake()
    {
        _loader = GetComponent<GameLoader>();

        _currentHealth = _healthAmount;

        Changed?.Invoke(_currentHealth);
    }

}
