using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _healthAmount = 100;
    private float _currentHealth;

    private CurrentHealthBar _healthBar;

    private void Awake()
    {
        _currentHealth = _healthAmount;

        _healthBar = transform.GetComponentInChildren<CurrentHealthBar>();
    }

    public void TakeDamage()
    {
        if (--_currentHealth <= 0)
        {
            Destroy(gameObject);
        }

        Vector3 newHealthScale = _healthBar.transform.localScale;
        newHealthScale.x = _currentHealth / _healthAmount;
        _healthBar.transform.localScale = newHealthScale;
    }
}
