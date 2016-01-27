using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerControllerNoYAxisFollow : MonoBehaviour
{

    public CameraControllerNoYAxisFollow myCameraController;

    /// <summary>
    /// Handle collisions, either by restarting, falling, or resetting our jumps.
    /// </summary>
    /// <param name="col">Information returned by a collision in 2D physics.</param>
    void OnCollisionEnter2D(Collision2D col)
    {
        myCameraController.__handlePlayerCollision(col);
    }
}
