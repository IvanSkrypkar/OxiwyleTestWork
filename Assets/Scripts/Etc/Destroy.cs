using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] float _time;
    void Start()
    {
        Destroy(gameObject, _time);
    }
}
