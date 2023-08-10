using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Enemy _template;
    [SerializeField] private float _sleepDuration;
    [SerializeField] private int _enemiesAmount;

    private SpawnPoint[] _spawnPoints;
    private WaitForSeconds _sleep;
    private int _currentSpawnerNumber = 0;

    private bool _isSpawning;

    private void Awake()
    {
        _spawnPoints = GetComponentsInChildren<SpawnPoint>();
        _sleep = new WaitForSeconds(_sleepDuration);
    }

    private void OnEnable()
    {
        _isSpawning = true;
        StartCoroutine(SpawnEnemiesCoroutine());
    }

    private void OnDisable()
    {
        _isSpawning = false;
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (_isSpawning)
        {
            Transform enemyTransform = _spawnPoints[_currentSpawnerNumber].transform;

            if (_enemiesAmount-- > 0)
                Instantiate(_template, enemyTransform.position, enemyTransform.rotation);

            if (++_currentSpawnerNumber >= _spawnPoints.Length)
                _currentSpawnerNumber = 0;

            yield return _sleep;
        }
    }
}
