using UnityEngine;

public class PlayerShipAnimatorController : MonoBehaviour
{
    [SerializeField] Animator _playerShipAnimator;
    [SerializeField] Animation _shipAnimation;

    public void SetRightTurnAnimation() => _playerShipAnimator.SetBool("RightTurn", true);
    public void SetLeftTurnAnimation() => _playerShipAnimator.SetBool("LeftTurn", true);
    public void ResetAnimation()
    {
        _playerShipAnimator.SetBool("RightTurn", false);
        _playerShipAnimator.SetBool("LeftTurn", false);
    }
    public void SetShipDamageAnimation() => _shipAnimation.Play("ShipDamaged");
}
