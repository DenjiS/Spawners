using System.Collections;
using UnityEngine;

public class SpawnsProgram : MonoBehaviour
{
    [SerializeField] private float _sleepDuration;

    private EnemySpawner[] _spawners;
    private WaitForSeconds _sleep;

    private int _currentSpawnerNumber = 0;
    private bool _isSpawning;

    void Awake()
    {
        _spawners = GetComponentsInChildren<EnemySpawner>();
        _sleep = new WaitForSeconds(_sleepDuration);
    }

    private void OnEnable()
    {
        _isSpawning = true;
        StartCoroutine(SpawnEnemy());
    }

    private void OnDisable()
    {
        _isSpawning = false;
    }

    private IEnumerator SpawnEnemy()
    {
        while (_isSpawning)
        {
            _spawners[_currentSpawnerNumber].Spawn();

            if (++_currentSpawnerNumber >= _spawners.Length)
                _currentSpawnerNumber = 0;

            yield return _sleep;
        }
    }
}
