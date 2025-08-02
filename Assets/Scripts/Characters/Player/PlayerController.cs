using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : CharacterBase
{
    #region Properties
    [SerializeField]
    private float speed = 3f;

    private Vector3 velocity;
    #endregion

    #region References
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private PlayerAnimationController animatorController;
    #endregion

    #region Methods
    private void Start()
    {
        if (!rb) 
        {
            rb = GetComponent<Rigidbody>();
        }
    }

    public override void OnCinematicEnd()
    {
        base.OnCinematicEnd();

        transform.position = GameManager.Instance.CinematicManager.PlayerPosition.position;
        transform.rotation = GameManager.Instance.CinematicManager.PlayerPosition.rotation;
    }

    public void OnMove(InputValue input)
    {
        var value = input.Get<Vector2>();

        if (value.magnitude > 1) 
        {
            value.Normalize();
        }

        velocity = new Vector3(value.x, 0, value.y) * speed;

        if (animatorController) 
        {
            animatorController.UpdateRunSpeed(velocity.magnitude);
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(velocity, ForceMode.VelocityChange);

        if (velocity != Vector3.zero) 
        {
            transform.forward = velocity.normalized;
        }
    }
    #endregion
}
