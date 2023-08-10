using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(EnemyFollowPlayer))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private AudioSource _dieSound;
    [SerializeField] private ParticleSystem _particles;
    [SerializeField] private float _secondsToDestroy;

    private Animator _animator;
    private Rigidbody _rigidbody;
    private EnemyFollowPlayer _follower;

    private Counter _killsCounter;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _follower = GetComponent<EnemyFollowPlayer>();
        _killsCounter = FindAnyObjectByType<Counter>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerHealth player))
        {
            _animator.SetBool("isNearPlayer", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerHealth player))
        {
            _animator.SetBool("isNearPlayer", false);
        }
    }

    public void GetDamage()
    {
        if (_follower.enabled)
        {
            _particles.Play();
            StartCoroutine(DestroyDelay());
        }
    }

    private IEnumerator DestroyDelay()
    {
        _killsCounter.Increment();
        AnimateDeath();

        yield return new WaitForSeconds(_secondsToDestroy);

        Destroy(gameObject);
    }

    private void AnimateDeath()
    {
        _animator.SetTrigger("onDying");
        _rigidbody.freezeRotation = true;
        _follower.enabled = false;
        _dieSound.Play();
    }
}