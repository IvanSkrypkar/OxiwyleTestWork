using UnityEngine;

public class VFXSpawner : MonoBehaviour
{
    [SerializeField] GameObject _bulletExplosionPrefab;
    [SerializeField] GameObject _asteroidExplosionPrefab;

    public void SpawnBulletExlosion(Transform position)
    {
        GameObject bulletExplosionVFX = Instantiate(_bulletExplosionPrefab, position.position, Quaternion.identity);
        bulletExplosionVFX.transform.SetParent(gameObject.transform);
        bulletExplosionVFX.transform.localScale = Vector3.one;
    }
    public void SpawnAsteroidExlosion(Transform position)
    {
        GameObject asteroidExplosionVFX = Instantiate(_asteroidExplosionPrefab, position.position, Quaternion.identity);
        asteroidExplosionVFX.transform.SetParent(gameObject.transform);
        asteroidExplosionVFX.transform.localScale = Vector3.one;
    }
}
