using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    #region Properties
    [SerializeField]
    private float _speed = 6f;

    private Vector3 _velocity;
    #endregion

    #region References
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private Animator _animator;
    #endregion

    #region Methods
    public void OnMove(InputValue input)
    {
        var value = input.Get<Vector2>();

        if (value.magnitude > 1) 
        {
            value.Normalize();
        }

        _velocity = new Vector3(value.x, 0, value.y) * _speed;

        if (_animator) 
        {
            _animator.SetFloat("RunSpeed", _velocity.magnitude);
        }
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_velocity, ForceMode.VelocityChange);
        transform.forward = _velocity.normalized;
    }
    #endregion
}
