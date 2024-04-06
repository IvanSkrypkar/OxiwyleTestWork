using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] int MaxRightPosX = 400;
    [SerializeField] int MaxLefttPosX = -400;
    [SerializeField] RectTransform _shipPositionMove;
    bool _isRightTouch = false;
    bool _isLeftTouch = false;

    void FixedUpdate()
    {
        if (_isRightTouch)
        {
            if(_shipPositionMove.localPosition.x < MaxRightPosX)
                MoveShip(0.1f);
        }
        else if (_isLeftTouch)
        {
            if (_shipPositionMove.localPosition.x > MaxLefttPosX)
                MoveShip(-0.1f);
        }
    }

    void MoveShip(float direction)
    {
        _shipPositionMove.Translate(Vector3.right * direction * speed * Time.fixedDeltaTime);
    }
    
    public void SetLeftTouch()
    {
        _isLeftTouch = true;
    }
    public void SetRightTouch()
    {
        _isRightTouch = true;
    }
    public void ResetTouch()
    {
        _isRightTouch = false;
        _isLeftTouch = false;
    }
}
