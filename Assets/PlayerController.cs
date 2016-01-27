using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public static float runSpeed = 10f; // X speed in Velocity
    public static float jumpHeight = 10f; // Y speed in Velocity
    public static int jumpCount = 2; // Max jumps (2 allows double jump etc)

    public CameraController myCameraController;

    private Collider2D myCollider;
    private Rigidbody2D myRigidbody;
    private bool isRunning = true;
    
    private bool isJumping = false; // This is only true for one physics frame
    public int jumpsLeft = 0;

    private bool hasInit = false; /* This is a fix for the webplayer */

    void Start()
    {
        if (myCameraController != null)
        {
            myCameraController.attachCamera(this);
        }
        else
        {
            Debug.LogWarning("CameraController missing");
        }
        myCollider = gameObject.GetComponent<Collider2D>();
        myRigidbody = gameObject.GetComponent<Rigidbody2D>();
        jumpsLeft = jumpCount;
    }
    
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R)) // Reload the level when R is released
        {
            _restartLevel();
        }
        else if (!isJumping && jumpsLeft > 0 && Input.GetKeyDown(KeyCode.Space)) // Jump when Space is pressed
        {
            isJumping = true;
            jumpsLeft--;
        }
    }

    void FixedUpdate()
    {
        if (isRunning)
        {
            if (myRigidbody != null)
            {
                if (hasInit && myRigidbody.velocity.x == 0f && myRigidbody.velocity.y == 0f) /* This is a fix for the webplayer */
                {
                    _stopRunning();
                }

                if (isJumping)
                {
                    isJumping = false;
                    myRigidbody.velocity = new Vector2(runSpeed, jumpHeight);
                }
                else
                {
                    myRigidbody.velocity = new Vector2(runSpeed, myRigidbody.velocity.y);
                }
            }
        }
        else
        {
            if (gameObject.transform.position.y < -15f) // We fell outside of the bounds (but our collider is disabled here)
            {
                _restartLevel();
            }
        }
    }

    /// <summary>
    /// Handle collisions, either by restarting, falling, or resetting our jumps
    /// </summary>
    /// <param name="c"></param>
    void OnCollisionEnter2D(Collision2D c)
    {
        hasInit = true; /* This is a fix for the webplayer */
        if (c.gameObject.GetComponent<BoundsController>() != null) // We hit the level bounds
        {
            _restartLevel();
        }
        if (myRigidbody.velocity.x == 0f) // We hit a wall. Webplayer doesn't seem to pick this up in time
        {
            _stopRunning();
        }
        else if (c.transform.position.y < gameObject.transform.position.y) // We hit the floor
        {
            jumpsLeft = jumpCount;
        }
    }

    void OnGUI()
    {
        if (myRigidbody != null)
        {
            GUILayout.Label(string.Format("isRunning: {0} isJumping: {1}", isRunning, isJumping));
            GUILayout.Label(string.Format("Velocity: {0}", myRigidbody.velocity.ToString()));
            GUILayout.Label(string.Format("Jumps: {0}", jumpsLeft.ToString()));
        }
    }

    /// <summary>
    /// Detach the camera and fall
    /// </summary>
    void _stopRunning()
    {
        isRunning = false;
        myCollider.enabled = false;
        if (myCameraController != null)
        {
            myCameraController.detachCamera();
        }
    }

    /// <summary>
    /// Reload this level
    /// </summary>
    void _restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
