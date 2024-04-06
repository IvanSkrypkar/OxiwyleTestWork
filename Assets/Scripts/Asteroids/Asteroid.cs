using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Resources")]
    Rigidbody2D rigidbody2D;
    [SerializeField] GameObject _parentObject;
    Animation _animation;
    VFXSpawner _vfxSpawner;
    SFXController _sfxController;
    PlayerShipAnimatorController _shipAnimatorController;
    GameScoreController _gameScoreController;

    [Header("Editable values")]
    [SerializeField, Range(0.5f, 1f)] float _minMoveForce;
    [SerializeField, Range(1f, 5f)] float _maxMoveForce;

    float _calculatedMoveForce;
    int _hp;
    
    

    private void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _animation = GetComponent<Animation>();
        _vfxSpawner = FindObjectOfType<VFXSpawner>();
        _sfxController = FindObjectOfType<SFXController>();
        _shipAnimatorController = FindObjectOfType<PlayerShipAnimatorController>();
        _gameScoreController = FindObjectOfType<GameScoreController>();

        _calculatedMoveForce = Random.Range(_minMoveForce, _maxMoveForce);
        _hp = Random.Range(2, 5);
    }

    private void FixedUpdate()
    {
        rigidbody2D.AddForce(transform.up * -_calculatedMoveForce);
    }

    void GetDamage(Transform collisionPosition, string tag = null)
    {
        _hp--;
        if (_hp <= 0)
        {
            _vfxSpawner.SpawnAsteroidExlosion(gameObject.transform);

            if (tag != null)
            {
                if (tag == "Bullet")
                    _gameScoreController.UpdateKillsCount();
            }
            _sfxController.AsteroidExplosion();
            Destroy(_parentObject);
        }
        _vfxSpawner.SpawnBulletExlosion(gameObject.transform);
        _animation.Play("AsteroidDamage");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GetDamage(collision.transform, collision.gameObject.tag);
            _sfxController.BulletHit();
        }
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            GetDamage(collision.transform);
            _sfxController.AsteroidHit();
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            _vfxSpawner.SpawnAsteroidExlosion(gameObject.transform);
            _shipAnimatorController.SetShipDamageAnimation();
            _gameScoreController.UpdateCollisionsCount();
            _sfxController.AsteroidExplosion();
            Destroy(_parentObject);
        }
        if (collision.gameObject.CompareTag("WorldEnd"))
        {
            Destroy(_parentObject);
        }
    }
}
