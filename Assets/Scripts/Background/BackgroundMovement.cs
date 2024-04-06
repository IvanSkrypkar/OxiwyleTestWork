using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] float _startPosY, _replacePosY,_finishPosY;
    [SerializeField] float _speed;
    Transform _transform;

    private void Start()
    {
        _transform = GetComponent<Transform>();
        SetStartPosition();
    }

    private void FixedUpdate()
    {
        _transform.Translate(Vector3.down * _speed * Time.fixedDeltaTime);

        if (_transform.localPosition.y <= _finishPosY)
            SetReplacePosition();
    }

    void SetStartPosition() => _transform.localPosition = new Vector3(0, _startPosY, 0);

    void SetReplacePosition() => _transform.localPosition = new Vector3(0, _replacePosY, 0);
}
