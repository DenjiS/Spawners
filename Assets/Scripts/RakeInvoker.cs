using DG.Tweening;
using UnityEngine;

public class RakeInvoker : MonoBehaviour
{
    [SerializeField] private float _raiseTime;
    [SerializeField] private float _fallTime;

    private readonly Vector3 _steppedRotation = new(0, 0, 90);

    private Sequence _moveTweens; 
    private bool _isPlaying = false;

    private void Awake()
    {
        _moveTweens = DOTween.Sequence(gameObject);
        _moveTweens.Append(transform.DOLocalRotate(_steppedRotation, _raiseTime));
        _moveTweens.Append(transform.DOLocalRotate(Vector3.zero, _fallTime));
        _moveTweens.onComplete = () => _isPlaying = false;
    }

    private void OnTriggerEnter(Collider collided)
    {
        if (collided.TryGetComponent(out PlayerHealth player) &&
            _isPlaying == false)
        {
            player.TakeDamage();
            _moveTweens.Play();
            _isPlaying = true;
        }
    }
}
