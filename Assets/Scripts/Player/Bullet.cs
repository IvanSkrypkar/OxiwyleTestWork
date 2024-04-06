using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(10f, 100f)] float _moveSpeed;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(0, 0.1f, 0) * _moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet") == false || collision.gameObject.CompareTag("Player"))
            Destroy(gameObject);
    }
}
