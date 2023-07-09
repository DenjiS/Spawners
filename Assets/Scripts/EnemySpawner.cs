using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemyTemplate;

    public void Spawn()
    {
        Instantiate(_enemyTemplate, transform.position, transform.rotation);
    }
}
