using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    #region Properties
    [SerializeField]
    private float _runningSpeedThreshold = 2f;

    [SerializeField]
    private float _maxRunningSpeed = 3f;
    #endregion

    #region References
    [SerializeField]
    private Animator _animator;
    #endregion

    #region Methods
    public void UpdateRunSpeed(float speed) 
    {
        _animator.SetFloat("RunSpeed", speed);
        float animSpeed = 1;
        // Change the animation speed to match the physic speed using predefined values for the threshold to start running and the max speed
        // Running animation
        if (speed > _runningSpeedThreshold)
        {
            // Scale running between 0.5 and 1 for better results
            animSpeed = (speed - _runningSpeedThreshold) / (_maxRunningSpeed - _runningSpeedThreshold) * 0.5f + 0.5f;
        }
        // Walking animation 
        else if (speed > 0.1f)
        {
            animSpeed = speed / _runningSpeedThreshold;
        }

        _animator.speed = animSpeed;
    }
    #endregion
}
