using UnityEngine;

public class SFXController : MonoBehaviour
{
    [SerializeField] AudioClip _asteroidExplosion, _asteroidHit, _gunShoot, _bulletHit;
    AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void GunShoot() => _audioSource.PlayOneShot(_gunShoot);
    public void BulletHit() => _audioSource.PlayOneShot(_bulletHit);
    public void AsteroidHit() => _audioSource.PlayOneShot(_asteroidHit);
    public void AsteroidExplosion() => _audioSource.PlayOneShot(_asteroidExplosion);
}
