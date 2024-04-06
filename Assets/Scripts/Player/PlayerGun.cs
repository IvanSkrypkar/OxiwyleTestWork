using System.Collections;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] GameObject _bulletPrefub;
    [SerializeField] Transform _bulletSpawnPosition;

    [Header("Shoot speed (seconds)")]
    [SerializeField, Range(0.1f,10)] float _spawnInterval;

    [Header("FX data")]
    [SerializeField] VFXSpawner _vfxSpawner;
    [SerializeField] SFXController _sfxController;

    private void Start()
    {
        StartCoroutine(SpawnBullets());
    }

    IEnumerator SpawnBullets()
    {
        yield return new WaitForSeconds(_spawnInterval);

        while (true)
        {
            GameObject BulletPrefab = Instantiate(_bulletPrefub, _bulletSpawnPosition.position, _bulletSpawnPosition.rotation);
            BulletPrefab.transform.SetParent(gameObject.transform);
            BulletPrefab.transform.localScale = Vector3.one;
            _vfxSpawner.SpawnBulletExlosion(_bulletSpawnPosition);
            _sfxController.GunShoot();

            yield return new WaitForSeconds(_spawnInterval);
        }
    }
}
