using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField] AudioSource _attackSound;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.TryGetComponent(out Player player))
        {
            _attackSound.Play();
            player.TakeDamage();
        }
    }
}
