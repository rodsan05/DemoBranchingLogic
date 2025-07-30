using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimationController : MonoBehaviour
{
    #region Properties
    [SerializeField]
    private float runningSpeedThreshold = 2f;

    [SerializeField]
    private float maxRunningSpeed = 3f;
    #endregion

    #region References
    [SerializeField]
    private Animator animator;
    #endregion

    #region Methods
    private void Awake()
    {
        if (!animator) 
        {
            animator = GetComponent<Animator>();
        }
    }

    public void UpdateRunSpeed(float speed) 
    {
        animator.SetFloat("RunSpeed", speed);
        float animSpeed = 1;
        // Change the animation speed to match the physic speed using predefined values for the threshold to start running and the max speed
        // Running animation
        if (speed > runningSpeedThreshold)
        {
            // Scale running between 0.5 and 1 for better results
            animSpeed = (speed - runningSpeedThreshold) / (maxRunningSpeed - runningSpeedThreshold) * 0.5f + 0.5f;
        }
        // Walking animation 
        else if (speed > 0.1f)
        {
            animSpeed = speed / runningSpeedThreshold;
        }

        animator.speed = animSpeed;
    }
    #endregion
}
