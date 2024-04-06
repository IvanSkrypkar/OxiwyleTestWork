using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AsteroidsSpawner : MonoBehaviour
{
    [Header("Resources")]
    [SerializeField] GameObject _asteroidPrefab;
    [SerializeField] Transform _spawnPosition;
    [SerializeField] Sprite[] _asteroidsImages;

    [Header("Spawn speed (seconds). Random, between two constraints")]
    [SerializeField, Range(0.1f, 1f)] float _minSpawnInterval;
    [SerializeField, Range(1f, 5f)] float _maxSpawnInterval;

    [Header("Random Scale between two constraints")]
    [SerializeField] float _minScale;
    [SerializeField] float _maxScale;


    void Start()
    {
        StartCoroutine(SpawnAsteroids());
    }

    IEnumerator SpawnAsteroids()
    {
        while (true)
        {
            GameObject AsteroidPrefab = Instantiate(_asteroidPrefab, new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(_spawnPosition.position.y, _spawnPosition.position.y + 1f), gameObject.transform.position.z), Quaternion.identity);
            AsteroidPrefab.transform.SetParent(gameObject.transform);

            float randomScale = Random.Range(_minScale, _maxScale);
            AsteroidPrefab.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
            
            int randomRotation = Random.Range(-10, 10);
            AsteroidPrefab.transform.localRotation = Quaternion.Euler(0, 0, randomRotation);
            
            Image asteroidImage = AsteroidPrefab.GetComponentInChildren<Image>();
            int randomImageNum = Random.Range(0, _asteroidsImages.Length);
            asteroidImage.sprite = _asteroidsImages[randomImageNum];

            yield return new WaitForSeconds(Random.Range(_minSpawnInterval, _maxSpawnInterval));
        }
    }
}
