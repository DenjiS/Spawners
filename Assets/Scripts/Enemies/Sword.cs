using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sword : MonoBehaviour
{
    AudioSource _attackSound;

    private void Awake()
    {
        _attackSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.TryGetComponent(out PlayerHealth player))
        {
            _attackSound.Play();
            player.TakeDamage();
        }
    }
}
