using UnityEngine;
using DG.Tweening;
using UnityEngine.VFX;

public class Gun : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _range;

    [SerializeField] private ParticleSystem _shotParticles;
    [SerializeField] private float _shotMoveTime = 0.3f;
    [SerializeField] private float _shotedGunXRotation = -45;

    private Sequence _shotAnimationSequence;
    private Vector3 _shootedRotation;

    private void Awake()
    {
        _shootedRotation = new Vector3(_shotedGunXRotation, 0, 0);

    }

    public void Shoot()
    {
        _shotParticles.Play();

        _shotAnimationSequence = DOTween.Sequence();
        float halfOfShotTime = _shotMoveTime / 2;
        _shotAnimationSequence.Append(transform.DOLocalRotate(_shootedRotation, halfOfShotTime));
        _shotAnimationSequence.Append(transform.DOLocalRotate(Vector3.zero, halfOfShotTime));

        if (Physics.Raycast(_camera.transform.position, _camera.transform.forward, out RaycastHit hit, _range) &&
            hit.collider.TryGetComponent(out Enemy enemy))
        {
            enemy.GetDamage();
        }

    }
}
