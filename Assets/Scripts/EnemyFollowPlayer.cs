using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = FindAnyObjectByType<Player>().transform;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
        transform.LookAt(_playerTransform);
    }
}
